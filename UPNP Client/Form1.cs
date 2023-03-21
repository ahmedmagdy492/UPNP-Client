using System.Linq;
using UPNP_Client.Models;

namespace UPNP_Client
{
    public partial class Form1 : Form
    {
        private readonly UPNPHandler _upnpHandler;
        private readonly SSDPClient _ssdpClient;
        private SSDPResponseModel _ssdpResponseModel;
        private List<DeviceService> deviceServices = new List<DeviceService>();

        public Form1()
        {
            InitializeComponent();
            _upnpHandler = new UPNPHandler();
            _ssdpClient = new SSDPClient();
        }

        private async Task OnRecvData(string data)
        {
            _ssdpResponseModel = _upnpHandler.ExtractHeaders(data);

            deviceServices.AddRange(await _upnpHandler.GetServiceList(_ssdpResponseModel.Location.Trim()));

            treeView1.Invoke(new Action(() =>
            {

                foreach (var service in deviceServices)
                {
                    bool serviceAlreadyExist = false;
                    foreach (TreeNode device in treeView1.Nodes)
                    {
                        if (service.ServiceID == device.Text)
                        {
                            serviceAlreadyExist = true;
                            break;
                        }
                    }

                    if (!serviceAlreadyExist)
                    {
                        var treeNode = new TreeNode(service.ServiceID);
                        treeNode.Tag = service.SCPDURL;
                        treeView1.Nodes.Add(treeNode);
                    }
                }

            }));
        }

        private async void btnMSearch_Click(object sender, EventArgs e)
        {
            deviceServices.Clear();
            ((Button)sender).Enabled = false;
            await _ssdpClient.SearchForDevices();
            ((Button)sender).Enabled = true;

            await _ssdpClient.RecvFromOtherDevices(OnRecvData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _ssdpClient.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.NodeMouseDoubleClick += (object sender, TreeNodeMouseClickEventArgs e) =>
            {
                var tag = e.Node.Tag.ToString();
                var service = deviceServices.Where(service => service.SCPDURL == tag).FirstOrDefault();
                var form = new ServiceActions(_ssdpResponseModel, service, _upnpHandler);
                form.ShowDialog();
            };
        }
    }
}
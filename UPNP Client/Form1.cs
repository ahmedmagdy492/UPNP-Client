using System.Linq;
using UPNP_Client.Models;

namespace UPNP_Client
{
    public partial class Form1 : Form
    {
        private readonly UPNPHandler _upnpHandler;
        private readonly SSDPClient _ssdpClient;
        private List<DeviceService> deviceServices = new List<DeviceService>();

        public Form1()
        {
            InitializeComponent();
            _upnpHandler = new UPNPHandler();
            _ssdpClient = new SSDPClient();
        }

        private async Task OnRecvData(string data)
        {
            var extractedInfo = _upnpHandler.ExtractHeaders(data);

            deviceServices.AddRange(await _upnpHandler.GetServiceList(extractedInfo.Location.Trim()));

            treeView1.Invoke(new Action(() => {

                treeView1.NodeMouseDoubleClick += (object sender, TreeNodeMouseClickEventArgs e) =>
                {
                    var tag = e.Node.Tag.ToString();
                    var service = deviceServices.Where(service => service.SCPDURL == tag).FirstOrDefault();
                    var form = new ServiceActions(extractedInfo, service, _upnpHandler);
                    form.ShowDialog();
                };

                foreach(var service in new HashSet<DeviceService>(deviceServices))
                {
                    var treeNode = new TreeNode(service.ServiceID);
                    treeNode.Tag = service.SCPDURL;
                    treeView1.Nodes.Add(treeNode);
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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPNP_Client.Models;

namespace UPNP_Client
{
    public partial class ServiceActions : Form
    {
        private readonly SSDPResponseModel _response;
        private readonly DeviceService _deviceService;
        private readonly UPNPHandler _upnpHandler;

        public ServiceActions(
            SSDPResponseModel response,
            DeviceService deviceService,
            UPNPHandler upnpHandler)
        {
            InitializeComponent();
            _response = response;
            _deviceService = deviceService;
            _upnpHandler = upnpHandler;
        }

        private async void ServiceActions_Load(object sender, EventArgs e)
        {
            var scpd = await _upnpHandler.GetActionsList(_response.Location, _deviceService.SCPDURL);

            dataGridActions.DataSource = scpd.ActionsList;
            dataGridTableState.DataSource = scpd.ServiceStateTable;

            dataGridActions.DoubleClick += delegate
            {
                if (dataGridActions.SelectedRows.Count == 1)
                {
                    string actionName = dataGridActions.SelectedRows[0].Cells[0].Value.ToString();
                    var action = scpd.ActionsList.FirstOrDefault(a => a.Name == actionName);
                    ActionArguments actionArguments = new ActionArguments(action.Arguments);
                    actionArguments.ShowDialog();
                }
            };
        }
    }
}

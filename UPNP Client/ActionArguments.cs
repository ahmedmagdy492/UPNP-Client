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
    public partial class ActionArguments : Form
    {
        private readonly List<DeviceActionArgument> _arguments;

        public ActionArguments(List<DeviceActionArgument> arguments)
        {
            InitializeComponent();
            _arguments = arguments;
        }

        private void ActionArguments_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _arguments;
        }
    }
}

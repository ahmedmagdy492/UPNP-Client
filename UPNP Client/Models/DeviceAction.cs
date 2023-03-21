using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPNP_Client.Models
{
    public class DeviceAction
    {
        public string Name { get; set; }
        public List<DeviceActionArgument> Arguments { get; set; } = new List<DeviceActionArgument>();
    }
}

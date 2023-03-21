using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPNP_Client.Models
{
    public class DeviceActionArgument
    {
        public string Name { get; set; }
        public string Direction { get; set; }
        public string RelatedStateVariable { get; set; }
    }
}

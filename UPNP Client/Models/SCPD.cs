using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPNP_Client.Models
{
    public class SCPD
    {
        public List<DeviceAction> ActionsList { get; set; } = new List<DeviceAction>();
        public List<StateVariable> ServiceStateTable { get; set; } = new List<StateVariable>();
    }
}

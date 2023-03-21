using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPNP_Client.Models
{
    public class DeviceService : IComparable<DeviceService>
    {
        public string ServiceType { get; set; }
        public string ServiceID { get; set; }
        public string ControlURL { get; set; }
        public string EventSubURL { get; set; }
        public string SCPDURL { get; set; }

        public int CompareTo(DeviceService other)
        {
            if (other == null) return 1;
            return this.ServiceID.CompareTo(other.ServiceID);
        }
    }
}

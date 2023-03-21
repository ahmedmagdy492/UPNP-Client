using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPNP_Client.Models
{
    public class SSDPResponseModel
    {
        public int Status { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Server { get; set; }
    }
}

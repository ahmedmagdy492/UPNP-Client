using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using UPNP_Client.Models;

namespace UPNP_Client
{
    internal class UPNPHandler
    {
        public SSDPResponseModel ExtractHeaders(string payload)
        {
            var ssdpResponse = new SSDPResponseModel();
            var props = ssdpResponse.GetType().GetProperties();

            string[] payloadLines = payload.Split("\r\n");

            string[] firstLineInfo = payloadLines[0].Split(" ");
            ssdpResponse.Status = Convert.ToInt32(firstLineInfo[1]);

            for(int i = 1;i < payloadLines.Length; i++)
            {
                foreach (var prop in props)
                {
                    var headers = payloadLines[i].Split(":");
                    if(headers.Length >= 2)
                    {
                        var headerName = headers[0];
                        var headerValue = headers[1];

                        if(headers.Length == 4)
                        {
                            headerValue += ":" + headers[2] + ":" + headers[3];
                        }

                        if (headerName.ToLower() == prop.Name.ToLower())
                        {
                            prop.SetValue(ssdpResponse, headerValue);
                        }
                    }
                }
            }

            return ssdpResponse;
        }

        public List<DeviceService> GetDeviceInfo(string location)
        {
            var uri = new Uri(location);

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(uri.Scheme + "://" + uri.Host + ":" + uri.Port)
            };

            HttpResponseMessage response = httpClient.GetAsync(uri.PathAndQuery).Result;
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(response.Content.ReadAsStream());

            var serviceList = xmlDoc.GetElementsByTagName("serviceList");

            var deviceAvailableServiceList = new List<DeviceService>();

            for (int i = 0;i < serviceList.Count; i++)
            {
                foreach(XmlElement node in serviceList[i].ChildNodes)
                {
                    deviceAvailableServiceList.Add(new DeviceService
                    {
                        ServiceType = node.FirstChild.FirstChild.Value,
                        ServiceID = node.ChildNodes[1].FirstChild.Value,
                        ControlURL = node.ChildNodes[2].FirstChild.Value,
                        EventSubURL = node.ChildNodes[3].FirstChild.Value,
                        SCPDURL = node.LastChild.FirstChild.Value,
                    });
                }
            }

            return deviceAvailableServiceList;
        }
    }
}

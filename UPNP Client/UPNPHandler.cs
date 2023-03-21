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
    public class UPNPHandler
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

        public async Task<List<DeviceService>> GetServiceList(string location)
        {
            var uri = new Uri(location);

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(uri.Scheme + "://" + uri.Host + ":" + uri.Port)
            };

            HttpResponseMessage response = await httpClient.GetAsync(uri.PathAndQuery);
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

        public async Task<SCPD> GetActionsList(string location, string servicePath)
        {
            var uri = new Uri(location);

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(uri.Scheme + "://" + uri.Host + ":" + uri.Port)
            };

            HttpResponseMessage response = await httpClient.GetAsync(servicePath);
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(response.Content.ReadAsStream());

            var scpd = xmlDoc.GetElementsByTagName("scpd");
            var scpdObject = new SCPD();

            for(int i = 0;i < scpd[0].ChildNodes.Count; i++)
            {
                if (scpd[0].ChildNodes[i].Name == "serviceStateTable")
                {
                    foreach(XmlElement stateVariable in scpd[0].ChildNodes[i])
                    {
                        scpdObject.ServiceStateTable.Add(new StateVariable
                        {
                            Name = stateVariable.FirstChild.FirstChild.Value,
                            DataType = stateVariable.FirstChild.LastChild.Value,
                        });
                    }
                }
                else if(scpd[0].ChildNodes[i].Name == "actionList")
                {
                    foreach (XmlElement action in scpd[0].ChildNodes[i])
                    {
                        var deviceAction = new DeviceAction
                        {
                            Name = action.FirstChild.FirstChild.Value,
                        };
                        scpdObject.ActionsList.Add(deviceAction);

                        foreach(XmlElement argument in action.ChildNodes)
                        {
                            if(argument.Name == "argumentList")
                            {
                                deviceAction.Arguments.Add(new DeviceActionArgument
                                {
                                    Name = argument.FirstChild.FirstChild.FirstChild.Value,
                                    Direction = argument.FirstChild.ChildNodes[1].FirstChild.Value,
                                    RelatedStateVariable = argument.LastChild.FirstChild.FirstChild.Value,
                                });
                            }
                        }
                    }
                }
            }

            return scpdObject;
        }
    }
}

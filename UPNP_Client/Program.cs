using UPNP_Client.Models;

namespace UPNP_Client
{
    internal class Program
    {
        private static UPNPHandler handler = new UPNPHandler();

        private static void OnRecvData(string data)
        {
            Console.WriteLine(data);

            var extractedInfo = handler.ExtractHeaders(data);

            var serviceList = handler.GetDeviceInfo(extractedInfo.Location.Trim());
        }

        static void Main(string[] args)
        {
            SSDPClient client = new SSDPClient();
            client.SearchForDevices();

            Console.CancelKeyPress += delegate {
                Console.WriteLine("Ctrl+C Detected Exiting...");
                client.Dispose();
            };

            client.RecvFromOtherDevices(OnRecvData);
            client.Dispose();
        }
    }
}
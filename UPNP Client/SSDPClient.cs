using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UPNP_Client
{
    internal class SSDPClient
    {
        private Socket _socket;
        private int _port;

        public delegate Task ReceiveSSDPResponse(string data);

        private bool _isRunning;

        public SSDPClient()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _port = 1900;
            _isRunning = true;
        }

        private void InitBufferArray(byte[] buffer)
        {
            for(int i = 0;i  < buffer.Length; i++)
            {
                buffer[i] = 0;
            }
        }

        public async Task SearchForDevices()
        {
            StringBuilder payload = new StringBuilder("M-SEARCH * HTTP/1.1\r\n");
            payload.Append("HOST: 239.255.255.250:1900\r\n");
            payload.Append("MAN: \"ssdp:discover\"\r\n");
            payload.Append("MX: 1\r\n");
            payload.Append("USER-AGENT: Ahmed Magdy Device\r\n");
            payload.Append("ST: upnp:rootdevice\r\n\r\n");

            await Task.Run(() => {
                _socket.SendTo(Encoding.UTF8.GetBytes(payload.ToString()), new IPEndPoint(IPAddress.Parse("239.255.255.250"), _port));
            });
        }

        public async Task RecvFromOtherDevices(ReceiveSSDPResponse callback)
        {
            if (_socket == null)
                throw new Exception("Uninitialized Socket");

            byte[] recvData = new byte[8192];
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            await Task.Run(async () =>
            {
                while (true)
                {
                    if(!_isRunning)
                    {
                        break;
                    }

                    InitBufferArray(recvData);

                    await _socket.ReceiveFromAsync(
                        new ArraySegment<byte>(recvData),
                        SocketFlags.None,
                        remoteEndPoint
                    );

                    await callback(Encoding.UTF8.GetString(recvData));
                }
            });

            Dispose();
        }

        public void Stop()
        {
            _isRunning = false;
        }

        private void Dispose()
        {
            if(_socket != null )
            {
                _socket.Close();
                _socket.Dispose();
            }
        }
    }
}

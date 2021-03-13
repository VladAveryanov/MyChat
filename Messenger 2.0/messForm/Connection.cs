using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace messForm
{
    public class Connection
    {
        private TcpClient client;
        public string Name;

        public void Connect()
        {
            client = new TcpClient("127.0.0.1", 7991);
        }

        public bool Authentification()
        {
            if (client != null)
            {
                var stream = client.GetStream();
                var buffer = new byte[1024];
                stream.Read(buffer, 0, buffer.Length);

                string response = Encoding.UTF8.GetString(buffer,0,7);

                if (response == "existed")
                    return true;            
            }
            return false;
        }

        public void Disconnect()
        {
            if (client != null)
            {
                string msg = "end";
                var stream = client.GetStream();
                var buffer = new byte[1024];
                buffer = Encoding.UTF8.GetBytes(msg);
                stream.Write(buffer, 0, buffer.Length);
                client.Dispose();
                client.Close();
            }
        }

        public void SendMessage(string msg)
        {
            if (client != null )
            {
                var stream = client.GetStream();
                var buffer = new byte[1024];
                buffer = Encoding.UTF8.GetBytes(msg);
                stream.Write(buffer, 0, buffer.Length);
            }
        }
        public string RecieveMessage()
        {
            while (client.Connected)
            {
                var stream = client.GetStream();
                string msg = "";
                var buffer = new byte[1024];
                stream.Read(buffer, 0, buffer.Length);
                msg = Encoding.UTF8.GetString(buffer);

                return msg;
            }
            return "";
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocket4Net;

namespace NfcAdapters.Backend.ServerConnection
{
    public class NfcServerClient
    {
        public string Server { get; }


        public NfcServerClient(string server)
        {
            Server = server;
        }

        public async Task<TagReadResponse<int>> ReadTagIdAsync(CancellationToken token)
        {
            using var client = new WebSocket(Server);
            using var onMessage = new AutoResetEvent(false);

            var message = "READ";
            var response = new TagReadResponse<int[]>();

            client.Opened += (s, e) =>
            {
                client.Send(message);
            };

            client.MessageReceived += (s, e) => 
            {
                response = JsonConvert.DeserializeObject<TagReadResponse<int[]>>(e.Message);
                onMessage.Set();
            };

            client.Open();

            if (! onMessage.WaitOne(30000))
            {
                throw new TimeoutException("No tag recognized");
            }

            onMessage.Close();
            client.Close();

            return response.GetTagUid();
        }

        private void Client_Opened(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

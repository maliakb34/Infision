using Infision.HubConfig;
using Microsoft.AspNetCore.SignalR;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infision
{
    public class MyHubContext
    {
        readonly IHubContext<MyHub> _hubContext;

        public MyHubContext(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendData(string signalrKey, string messagingData)
        {
            string normalizedKey = string.IsNullOrWhiteSpace(signalrKey)
                ? SignalRDefaults.UdpRealtimeKey
                : signalrKey.Trim();
            await _hubContext.Clients.Group(normalizedKey).SendAsync("ReceiveMessage", messagingData);

        }
    }
}

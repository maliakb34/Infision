
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

        public async Task SendData(string user, string messagingData)
        {

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "user", messagingData);

        }
    }
}

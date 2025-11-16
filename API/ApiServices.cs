using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infision.API
{
    public sealed class APIServices : BackgroundService
    {
        private readonly ILogger<APIServices> _logger;

        public APIServices(ILogger<APIServices> log)
        {
            _logger = log;
           
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("APIServices started.");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("APIServices tick @ {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}

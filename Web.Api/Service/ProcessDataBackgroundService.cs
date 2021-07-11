using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Api.Service
{
    public class ProcessDataBackgroundService : BackgroundService
    {
        private readonly ILogger<ProcessDataBackgroundService> _logger;

        public ProcessDataBackgroundService(ILogger<ProcessDataBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            for (var i = 1; !stoppingToken.IsCancellationRequested; i++)
            {
                _logger.LogInformation($"Loop #{i}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

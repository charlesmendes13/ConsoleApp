using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    public class ConsoleApp : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifeTime;
        private readonly ILogger<ConsoleApp> _logger;

        public ConsoleApp(IHostApplicationLifetime appLifeTime,
            ILogger<ConsoleApp> logger)
        {
            _appLifeTime = appLifeTime;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifeTime.ApplicationStarted.Register(() =>
            {
                Task.Run(() =>
                {
                    try
                    {
                        _logger.LogInformation("Hello World!");
                    }
                    catch (Exception ex)
                    {

                    }

                    finally
                    {
                        _appLifeTime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

using BeerUI.Configuration;
using BeerUIApp;
using BeerUIApp.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace BeerUI.Tests
{
    public class TestServerFixture
    {
        public IHost Host { get; private set; }

        public TestServerFixture()
        {
            Host = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.development.json", optional: false);
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<HttpClient>();
                    services.AddTransient<IBeerUseCase, BeerUseCase>();

                    services.AddOptions<PunkAPIConfiguration>()
                    .Configure<IConfiguration>((options, configuration) =>
                    {
                        options.BaseURL = configuration["PunkAPI:BaseURL"];
                    });

                }).Build();
        }
    }
}

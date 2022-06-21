using BeerUI.Configuration;
using BeerUIApp.UseCases;

namespace BeerUIApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions();
            services.AddSingleton(configuration);
            services.AddSingleton<HttpClient>();
            services.AddTransient<IBeerUseCase, BeerUseCase>();

            services.Configure<PunkAPIConfiguration>(options => configuration
                .GetSection("PunkAPI")
                .Bind(options));
        }
    }
}
using LojaHiper.WebApp.MVC.Services;
using LojaHiper.WebApp.MVC.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LojaHiper.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<ICatalogoService, CatalogoService>();
        }
    }
}

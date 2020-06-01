using LojaHiper.Catalogo.API.Date;
using LojaHiper.Catalogo.API.Date.Repository;
using LojaHiper.Catalogo.API.Interfaces;
using LojaHiper.Catalogo.API.Services;
using LojaHiper.Catalogo.API.UoW;
using LojaHiper.Core.Date;
using LojaHiper.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace LojaHiper.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CatalogoContext>();
            
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

        }
    }
}

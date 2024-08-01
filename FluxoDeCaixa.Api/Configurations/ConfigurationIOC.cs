using FluxoDeCaixa.Api.Infra.Context;
using FluxoDeCaixa.Api.Service.Interface;
using FluxoDeCaixa.Api.Service.Service;
using FluxoDeCaixa.Api.Infra.Interface;
using Microsoft.EntityFrameworkCore;
using FluxoDeCaixa.Api.Infra.Repositories;

namespace FluxoDeCaixa.Api.Configurations
{
    public static class ConfigurationIOC
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DataContext>();
            var connectionString = configuration.GetConnectionString("connection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            //Services
            services.AddScoped<ILancamentoService, LancamentoService>();


            //Repositories
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
        }
    }
}

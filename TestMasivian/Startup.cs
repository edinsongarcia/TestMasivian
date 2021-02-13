using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using TestMasivian.DataManager;
using TestMasivian.Interfaces;
using TestMasivian.Models;
using TestMasivian.Services;

namespace TestMasivian
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(Configuration.GetSection("RedisConnection").Value));
            services.AddSingleton<IRepository<Roulette>, RouletteRepository>();
            services.AddSingleton<IRouletteService, RouletteService>();
            services.AddSingleton<IRepository<Bet>, BetRepository>();
            services.AddSingleton<IBetService, BetService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
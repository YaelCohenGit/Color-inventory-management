using BL.API;
using BL.Implementation;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class BLManager
    {
        public ColorsService colorsService { get; }
        public BLManager(string connString)
        {
            ServiceCollection services = new();
            services.AddScoped<DalManager>();
            services.AddScoped(d => new DalManager(connString));
            services.AddScoped<IColorsService, ColorsService>();

            ServiceProvider servicesProvider = services.BuildServiceProvider();
            colorsService = (ColorsService)servicesProvider.GetRequiredService<IColorsService>();
        }
    }
}

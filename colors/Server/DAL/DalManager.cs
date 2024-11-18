using DAL.API;
using DAL.Implementation;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalManager
    {
        public ColorsRepo Colors { get; }
        public DalManager(string connString)
        {
            ServiceCollection services = new();
            services.AddDbContext<DBContext>((op => op.UseSqlServer(connString)));

            services.AddScoped<IColorsRepo, ColorsRepo>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Colors = (ColorsRepo)serviceProvider.GetRequiredService<IColorsRepo>();
        }
    }
}

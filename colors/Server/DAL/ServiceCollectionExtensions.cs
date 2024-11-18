using DAL.API;
using DAL.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IColorsRepo, ColorsRepo>();
        }
    }
}

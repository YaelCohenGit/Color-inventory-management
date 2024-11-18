using BL.API;
using BL.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection collection)
        {
            collection.AddScoped<IColorsService, ColorsService>();
            collection.AddRepositories(); 
            return collection;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddModelRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(MapperConfigs).Assembly);
            return services;
        }
    }
}

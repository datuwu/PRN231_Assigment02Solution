using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyInjections
    {
        public static void AddModelServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
        }
    }
}

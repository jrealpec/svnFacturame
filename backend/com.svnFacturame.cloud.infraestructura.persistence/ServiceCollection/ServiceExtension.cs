using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using com.svnFacturame.cloud.infraestructura.persistence.Data;



namespace com.svnFacturame.cloud.infraestructura.persistence.ServiceCollection
{
  public static class ServiceExtension
  {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
            configuration = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();
            /* Contextos de Bases de Datos. */
            services.AddDbContext<asaCloud_Context>(options => { options.UseSqlServer(configuration.GetConnectionString("asacloudDatabase")); });

      /* DbFactory pattern. */
      /* Agregar aquí las implementaciones de Factory Pattern, asociadas a cada conexto de Base de Datos... */
      services.AddScoped<Func<asaCloud_Context>>((provider) => () => provider.GetService<asaCloud_Context>());
    }
  }
}

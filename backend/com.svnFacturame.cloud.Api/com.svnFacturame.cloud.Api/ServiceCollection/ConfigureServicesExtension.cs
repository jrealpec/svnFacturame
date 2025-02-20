using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;


using com.svnFacturame.cloud.infraestructura.persistence.ServiceCollection;

using com.svnFacturame.cloud.api.Middleware;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace com.svnFacturame.cloud.api.ServiceCollection
{
  public static class ConfigureServicesExtension
  {
    public static void InitConfigurationAPI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceLayer(configuration);
        services.AddTransient<ErrorHandlerMiddleware>();
            services.AddControllers();
        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.UseCamelCasing(true);
            options.SerializerSettings.Culture = System.Globalization.CultureInfo.CurrentCulture;
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            options.SerializerSettings.FloatFormatHandling = Newtonsoft.Json.FloatFormatHandling.DefaultValue;
            options.SerializerSettings.FloatParseHandling = Newtonsoft.Json.FloatParseHandling.Decimal;
        });
        services.AddSwaggerGen();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Implement Swagger UI",
                Description = "A simple example to Implement Swagger UI",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Juan Enrique Realpe",
                    Email = "jrealpec@hotmail.com",
                    Url = new Uri("https://github.com/jrealpec"),
                },
                License = new OpenApiLicense
                {
                    Name = "License Information",
                    Url = new Uri("https://swagger.io/specification/"),
                }
            });
        });
    }
  }
}

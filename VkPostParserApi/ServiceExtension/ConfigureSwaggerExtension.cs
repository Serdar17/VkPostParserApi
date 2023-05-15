using System.Reflection;
using Microsoft.OpenApi.Models;

namespace VkPostParserApi.ServiceExtension;

public static class ConfigureSwaggerExtension
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Vk Posts Parser API",
                Description = "ASP.NET Core 7.0 Web API"
            });
            
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}
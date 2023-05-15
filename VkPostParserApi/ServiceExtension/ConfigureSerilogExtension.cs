using Serilog;

namespace VkPostParserApi.ServiceExtension;

public static class ConfigureSerilogExtension
{
    public static void ConfigureSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        hostBuilder.UseSerilog();
    }
}
using Microsoft.EntityFrameworkCore;
using VkPostParserApi.Data;
using VkPostParserApi.Infrastructure.Client;
using VkPostParserApi.Infrastructure.Services;
using VkPostParserApi.Options;
using VkPostParserApi.Policy;
using VkPostParserApi.Repository;
using VkPostParserApi.ServiceExtension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<VkPostsApiOption>(builder.Configuration.GetSection(VkPostsApiOption.Section));

builder.Services.AddHttpClient<IVkPostClient, VkPostClient>()
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .AddPolicyHandler(RetryPolicy.GetRetryPolicy());

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetValue<string>("ConnectionString:DefaultConnection"));
});


builder.Services.AddScoped<IVkPostsParserService, VkPostParserService>();
builder.Services.Decorate<IVkPostsParserService, CachedVkPostsParserService>();

builder.Services.AddScoped<IOccurrenceLetterRepository, OccurrenceLetterRepository>();

builder.Services.AddMemoryCache();

#region Cors Configure

builder.Services.ConfigureCors();

#endregion

#region Swagger Configuration

builder.Services.ConfigureSwagger();

#endregion

#region Configure Serilog

builder.Host.ConfigureSerilog(builder.Configuration);

#endregion

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("EnableCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
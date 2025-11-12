using Infision;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder.Extensions;
using System.Globalization;
using Infision.Kafka;
using Infision.MHCP;
using Infision.MHCP.Core;
using Infision.Configure;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);




string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));

//Infision.Configure.RootSetting.Roots.AppSettings.DBRedisConnection = "127.0.0.1,abortConnect=false,syncTimeout=50000";

Infision.Configure.RootSetting.Roots = JsonSerializer.Deserialize<Infision.Configure.Root>(File.ReadAllText(projectRoot + "appsettings.json"));
Infision.Configure.RootSetting.Roots.AppSettings.StoragePath = projectRoot;



builder.Services.AddSignalR(); // Add services before Build()

builder.Services.AddTransient<MyHubContext>();




builder.Services.Configure<Infision.Configure.NetworkSettings>(opt =>
{
    var src = Infision.Configure.RootSetting.Roots.AppSettings.NetworkSetting;

});

builder.Services.AddSingleton<IDiscoveryRegistry, DiscoveryRegistry>();
builder.Services.AddSingleton<EventRequest>();
builder.Services.AddSingleton<EventResponse>();
builder.Services.AddSingleton<ConnectionManager>();
builder.Services.AddSingleton<IKafkaProducer, KafkaProducerService>();

//builder.Services.AddHostedService<DiscoveryService>();
builder.Services.AddHostedService<ConnectionListenerService>();
builder.Services.AddHostedService<ConnectionHostedService>();
builder.Services.AddHostedService<KafkaConsumerService>();









builder.Services.AddHostedService<UdpListenerService>();
//builder.Services.AddHostedService<Inticators>();



var app = builder.Build();

// SignalR Hub
app.MapHub<MyHub>("/myhub");

// (opsiyonel) Prometheus endpoint
//app.MapGet("/metrics", () => Results.Text(Infision.Inticators.ToPromText(), "text/plain; version=0.0.4"));



// Basit API
app.MapGet("/health", () => new { status = "ok", time = DateTimeOffset.UtcNow });
app.MapPost("/api/echo", async (HttpContext ctx) =>
{
    using var reader = new StreamReader(ctx.Request.Body, Encoding.UTF8);
    var body = await reader.ReadToEndAsync();
    return Results.Ok(new { you_sent = body });
});


// Kestrel'i console’dan istediğimiz URL’ye bağlarız
var optVal = app.Services.GetRequiredService<IOptions<Infision.Configure.NetworkSettings>>().Value;
app.Urls.Add(optVal.HttpUrl);

// Bu satırdan sonra process hem web’i hem background servisleri **aynı anda** koşturur
await app.RunAsync();

//Scaffold - DbContext "Host=localhost;Port=5432;Database=infisiondb;Username=appuser;Password=app123" Npgsql.EntityFrameworkCore.PostgreSQL - OutputDir "EF\Models" - ContextDir "EF" - Context "InfisionDbContext" - DataAnnotations - UseDatabaseNames - Schemas "public" - Force - Project Infision







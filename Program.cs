using Infision;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Infision.Kafka;
using Infision.MHCP;
using Infision.MHCP.TCP;
using Infision.MHCP.UDP;
using Infision.Configure;
using System.Text.Json;
using Infision.API.Endpoints;


var builder = WebApplication.CreateBuilder(args);




string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));


RootSetting.Roots = JsonSerializer.Deserialize<Root>(File.ReadAllText(projectRoot + "appsettings.json"));
RootSetting.Roots.AppSettings.StoragePath = projectRoot;






builder.Services.Configure<NetworkSettings>(opt =>
{
    var src = RootSetting.Roots.AppSettings.NetworkSetting;

});

builder.Services.AddSingleton<RegistryDevices>();
builder.Services.AddSingleton<EventRequest>();
builder.Services.AddSingleton<EventResponse>();
builder.Services.AddSingleton<Organizator>();
builder.Services.AddSingleton<TCPListener>();
builder.Services.AddHostedService<TcpHostedService>();
builder.Services.AddSingleton<PumpDataParser>();
builder.Services.AddSingleton<PatientStationAnalyzer>();
builder.Services.AddSingleton<UdpListener>();
builder.Services.AddSingleton<UdpEventRequest>();
builder.Services.AddSingleton<UdpEventResponse>();
builder.Services.AddSingleton<UdpHeartbeatService>();

builder.Services.AddHostedService<UdpHostedService>();


builder.Services.AddSingleton<IKafkaProducer, ProducerService>();

//builder.Services.AddHostedService<ConsumerService>();






//builder.Services.AddHostedService<Inticators>();



// SignalR REGISTER //
builder.Services.AddSignalR();
builder.Services.AddTransient<MyHubContext>();
// SignalR REGISTER //



// SWAGGER REGISTER //
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new() { Title = "Infision API", Version = "v1" });
});
// SWAGGER REGISTER //



var app = builder.Build();




// SignalR Hub
app.MapHub<MyHub>("/myhub");


// SWAGGER MIDDLEWARE //
app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";                     // http://host:port/swagger
    c.SwaggerEndpoint("v1/swagger.json", "Infision API v1");
});

app.Endpointlist();
// SWAGGER MIDDLEWARE //



var optVal = Infision.Configure.RootSetting.Roots.AppSettings.NetworkSetting;
app.Urls.Add(optVal.HttpUrl);

await app.RunAsync();

//Scaffold - DbContext "Host=localhost;Port=5432;Database=infisiondb;Username=appuser;Password=app123" Npgsql.EntityFrameworkCore.PostgreSQL - OutputDir "EF\Models" - ContextDir "EF" - Context "InfisionDbContext" - DataAnnotations - UseDatabaseNames - Schemas "public" - Force - Project Infision

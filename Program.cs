
using Infision;
using Infision.API.Endpoints;
using Infision.Configure;
using Infision.Data;
using Infision.Data.Models;
using Infision.Kafka;
using Infision.MHCP;
using Infision.MHCP.TCP;
using Infision.MHCP.UDP;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Data.Entity;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
RootSetting.Roots = JsonSerializer.Deserialize<Root>(File.ReadAllText(projectRoot + "appsettings.json"));
RootSetting.Roots.AppSettings.StoragePath = projectRoot;
RootSetting.Roots.AppSettings.Departments = new DBContext().Departments.Select(p => p.name).ToList();






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

// Quick test endpoint to push messages via SignalR groups.
app.MapPost("/signalr/send", async (MyHubContext hubCtx, string key, string message) =>
{
    await hubCtx.SendData(key, message);
    return Results.Ok(1);
});


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

//Scaffold-DbContext "Host=localhost;Port=5432;Database=infisiondb;Username=appuser;Password=app123" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir "Data\Models" -ContextDir "Data" -Context "InfisionDbContext" -DataAnnotations -UseDatabaseNames -Schemas "public" -Force -Project Infision

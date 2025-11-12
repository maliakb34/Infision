using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Infision.API.Endpoints;

public static class EndPoints
{
    public static IEndpointRouteBuilder Endpointlist(this IEndpointRouteBuilder endpoints)
    {
        // === Ana grup (/health) ===
        var group = endpoints.MapGroup("/health")
            .WithTags("Health");

        // 1️⃣ Basit health kontrolü
        group.MapGet("/", () => new
        {
            status = "ok",
            time = DateTimeOffset.UtcNow
        })
        .WithName("HealthCheck")
        .WithSummary("Sistemin canlı olup olmadığını döndürür.");

        // 2️⃣ Versiyon bilgisi
        group.MapGet("/version", () => new
        {
            version = typeof(Program).Assembly.GetName().Version?.ToString(),
            name = "Infision API"
        })
        .WithName("VersionInfo")
        .WithSummary("API sürüm bilgisini döndürür.");

        // 3️⃣ Sistem zamanı (örnek parametreli endpoint)
        group.MapGet("/time/{zone?}", (string? zone) =>
        {
            DateTimeOffset time;
            if (!string.IsNullOrWhiteSpace(zone))
            {
                try
                {
                    time = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow,
                        TimeZoneInfo.FindSystemTimeZoneById(zone));
                }
                catch
                {
                    return Results.BadRequest(new { error = "Geçersiz timezone" });
                }
            }
            else time = DateTimeOffset.UtcNow;

            return Results.Ok(new { utc = DateTimeOffset.UtcNow, local = time, zone });
        })
        .WithName("TimeInfo")
        .WithSummary("UTC ve belirtilen saat dilimindeki zamanı döndürür.");

        // 4️⃣ Opsiyonel özel test endpointi
        group.MapPost("/echo", async (HttpContext ctx) =>
        {
            using var reader = new StreamReader(ctx.Request.Body);
            var body = await reader.ReadToEndAsync();
            return Results.Ok(new { received = body });
        })
        .WithName("EchoHealth");

        return endpoints;
    }
}

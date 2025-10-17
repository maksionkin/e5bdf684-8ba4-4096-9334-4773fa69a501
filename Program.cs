using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WealthWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AssetDbContext>(options =>
    options.UseInMemoryDatabase("wealth")
    .UseAsyncSeeding(async (context, seed, cancellationToken) =>
    {
        if (seed)
        {
            var assetContext = (AssetDbContext)context;

            var assets = JsonSerializer.Deserialize<List<Asset>>(File.ReadAllText("Data/assets.json"), JsonSerializerOptions.Web)!;

            assetContext.AddRange(assets);

            await assetContext.SaveChangesAsync(cancellationToken);
        }
    }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "API"));
}

app.UseHttpsRedirection();


app.MapGet("/assets", async (DateTimeOffset asAt, AssetDbContext db, CancellationToken cancellationToken) =>
{

    await db.Database.EnsureCreatedAsync(cancellationToken);

    return await db.Assets.Where(a => a.BalanceAsOf <= asAt)
        .GroupBy(a => a.AssetInfoType)
        .Select(g => g
            .OrderByDescending(r => r.BalanceAsOf)
            .First())
        .ToListAsync(cancellationToken);
})
    .WithName("GetAssets");

await app.RunAsync();


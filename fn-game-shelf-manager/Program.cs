using GameShelfManager.CrossCutting;
using GameShelfManager.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureServices((context, services) =>
    {
        var connectionString = Environment.GetEnvironmentVariable("connDb")
                             ?? "Server=(localdb)\\mssqllocaldb;Database=GameShelfDb;Trusted_Connection=True;";

        // Register dependencies
        services.AddScoped<GameRepository>();
        services.AddDbContext<GameShelfContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        // Optional: Logging to console/debug
        services.AddLogging(config =>
        {
            config.AddConsole();
            config.AddDebug();
        });
    })
    .Build();

await host.RunAsync();
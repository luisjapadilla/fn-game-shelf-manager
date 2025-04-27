using GameShelfManager.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices((context, services) =>
    {
        var connectionString = Environment.GetEnvironmentVariable("connDb")
                             ?? "Server=(localdb)\\mssqllocaldb;Database=GameShelfDb;Trusted_Connection=True;";

        services.AddDbContext<GameShelfContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    })
    .Build();

await host.RunAsync();

using GameShelfManager.CrossCutting;
using GameShelfManager.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
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

    })
    .Build();

host.Run();
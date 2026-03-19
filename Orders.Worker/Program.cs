using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Orders.Infrastructure;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // 🔥 DB
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                "Server=localhost,1433;Database=OrdersDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True"));

        // 🔥 Consumer
        services.AddSingleton<RabbitMQConsumer>();
    })
    .Build();

// 🔥 Ejecutar consumer
var consumer = host.Services.GetRequiredService<RabbitMQConsumer>();
consumer.Start();

Console.ReadLine();
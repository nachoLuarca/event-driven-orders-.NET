using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Orders.Domain;

namespace Orders.Infrastructure;

public class RabbitMQConsumer
{
    private readonly ApplicationDbContext _db;

    public RabbitMQConsumer(ApplicationDbContext db)
    {
        _db = db;
    }

    public void Start()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "orders",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        Console.WriteLine("🟢 Esperando órdenes...");

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"📥 Mensaje recibido: {message}");

            var order = JsonSerializer.Deserialize<Order>(message);

            if (order != null)
            {
                try
                {
                    Console.WriteLine("👉 Guardando en DB...");

                    _db.Orders.Add(order);
                    _db.SaveChanges();

                    Console.WriteLine($"💾 Orden guardada: {order.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error guardando: {ex.Message}");
                }
            }
        };

        channel.BasicConsume(
            queue: "orders",
            autoAck: true,
            consumer: consumer
        );
    }
}       
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Orders.Domain;

namespace Orders.Infrastructure;

public class RabbitMQConsumer
{
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
            durable: false, // igual que el publisher por ahora
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
                Console.WriteLine($"✅ Orden procesada: {order.Id}");
            }
        };

        channel.BasicConsume(
            queue: "orders",
            autoAck: true,
            consumer: consumer
        );
    }
}
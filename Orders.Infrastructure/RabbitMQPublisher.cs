using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Orders.Domain;


namespace Orders.Infrastructure;

public class RabbitMQPublisher
{
    public void Publish(Order order)
    {
        var factory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "orders",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var message = JsonSerializer.Serialize(order);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "",
                             routingKey: "orders",
                             basicProperties: null,
                             body: body);

        Console.WriteLine($"📤 Orden enviada: {order.Id}");
    }
}
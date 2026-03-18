using Orders.Infrastructure;

var consumer = new RabbitMQConsumer();
consumer.Start();

Console.ReadLine(); // para mantener vivo el proceso

// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory() { HostName = "localhost"};
using(var connection = factory.CreateConnection())
{
    using(var chanel = connection.CreateModel())
    {
        chanel.QueueDeclare(queue: "first",
            exclusive: false,
            durable: true,
            autoDelete: false,
            arguments: null);

        var message = "second message";
        var body = Encoding.UTF8.GetBytes(message);

        chanel.BasicPublish(exchange:"" ,routingKey:"first", basicProperties: null, body:body);

        Console.WriteLine("Done");
    }
}

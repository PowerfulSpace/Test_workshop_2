using RabbitMQ.Client;
using System.Text;


// Устанавливаем соединение с сервером RabbitMQ
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    // Объявляем очередь, в которую будем отправлять сообщения
    channel.QueueDeclare(queue: "hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    string message = "Hello RabbitMQ!";
    var body = Encoding.UTF8.GetBytes(message);

    // Отправляем сообщение в очередь
    channel.BasicPublish(exchange: "",
                         routingKey: "hello",
                         basicProperties: null,
                         body: body);
    Console.WriteLine($" [x] Sent {message}");
}


Console.ReadLine();
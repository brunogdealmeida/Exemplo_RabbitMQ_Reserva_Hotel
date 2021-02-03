using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AdministracaoHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "teste", Password = "teste" };

            using (var connectionFactory = factory.CreateConnection()) 
            using (var channel = connectionFactory.CreateModel())
            {
                var consumerMessage = new EventingBasicConsumer(channel);

                consumerMessage.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine($"Hotel ABC Registry: {message}");
                };

                channel.BasicConsume(queue: "Registry", autoAck: true, consumer: consumerMessage);

                Console.WriteLine("Para SAIR pressione Enter");
                Console.ReadKey();
            }
        }
    }
}

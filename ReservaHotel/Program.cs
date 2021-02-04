using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace ReservaHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Console.WriteLine("Olá, a reserva será feita para quantas pessoas ?");
            count = Int32.Parse(Console.ReadLine());

            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "teste", Password = "teste" };

            using (var connectionFactory = factory.CreateConnection())
            using (var channel = connectionFactory.CreateModel())
            {
                channel.QueueDeclare(queue: "Registry",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                while (count >= 1)
                {
                    var message = $"Reserva nº { Guid.NewGuid().ToString() } no Hotel ABC registrada com sucesso.";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "Registry", basicProperties: null, body: body);

                    Console.WriteLine($"Mensagem enviada com sucesso: {message}");
                    Thread.Sleep(300);
                    count--;
                }
            }
        }
    }
}

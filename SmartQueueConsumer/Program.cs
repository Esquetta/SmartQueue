using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory connectionFactory = new ConnectionFactory();
connectionFactory.Uri = new Uri("amqps://nmlgtsid:Hl-ZajX0FHO3eG52BQnrPKc8aQpkYTsd@sparrow.rmq.cloudamqp.com/nmlgtsid");

using (IConnection connection = connectionFactory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("iskuyrugu", true, false, true, null);
    channel.BasicQos(0, 1, false);

    EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("iskuyrugu", false, eventingBasicConsumer);

    eventingBasicConsumer.Received += (sender, e) =>
    {
        Thread.Sleep(1000);
        Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()) + " alındı");
        channel.BasicAck(e.DeliveryTag, false);
    };
    Console.Read();
}
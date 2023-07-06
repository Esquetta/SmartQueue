


using RabbitMQ.Client;
using System.Text;

ConnectionFactory connectionFactory = new ConnectionFactory();
connectionFactory.Uri = new Uri("amqps://nmlgtsid:Hl-ZajX0FHO3eG52BQnrPKc8aQpkYTsd@sparrow.rmq.cloudamqp.com/nmlgtsid");


using (IConnection connection = connectionFactory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("iskuyrugu", true, false, true, null);
    for (int i = 0; i < 100; i++)
    {
        byte[] byteMessage = Encoding.UTF8.GetBytes($"is {i}");
        IBasicProperties properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: "", routingKey: "iskuyrugu", properties, body: byteMessage);
    }
}
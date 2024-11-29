public interface IQueueService
{
    Task SendMessageAsync<T>(List<T> serviceBusMessage, string queueName);
}
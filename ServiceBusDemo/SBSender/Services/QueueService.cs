﻿using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Azure.Identity;

namespace SBSender.Services
{
    public class QueueService : IQueueService
    {

        // name of your Service Bus queue
        // the client that owns the connection and can be used to create senders and receivers
        ServiceBusClient serviceBusClient;

        // the sender used to publish messages to the queue
        ServiceBusSender serviceBusSender;

        // number of messages to be sent to the queue
        const int numOfMessages = 3;

        public readonly IConfiguration _config;
        public QueueService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMessageAsync<T>(List<T> serviceBusMessage, string queueName)
        {
            string? serviceBusConn = _config.GetConnectionString("AzureServiceBus");

            var clientOptions = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };

            if (serviceBusConn != null)
            {
                serviceBusClient = new ServiceBusClient(serviceBusConn);
                serviceBusSender = serviceBusClient.CreateSender(queueName);
                using ServiceBusMessageBatch messageBatch = await serviceBusSender.CreateMessageBatchAsync();

                foreach (T item in serviceBusMessage)
                {
                    ServiceBusMessage msg = new ServiceBusMessage(JsonSerializer.Serialize<T>(item));
                    msg.ContentType = "application/json";
                    messageBatch.TryAddMessage(msg);
                    await serviceBusSender.SendMessagesAsync(messageBatch);
                }
            }

        }

/*
        public async Task SendMessage()
        {


            // The Service Bus client types are safe to cache and use as a singleton for the lifetime
            // of the application, which is best practice when messages are being published or read
            // regularly.
            //
            // Set the transport type to AmqpWebSockets so that the ServiceBusClient uses the port 443. 
            // If you use the default AmqpTcp, ensure that ports 5671 and 5672 are open.
            var clientOptions = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };
            //TODO: Replace the "<NAMESPACE-NAME>" and "<QUEUE-NAME>" placeholders.
            client = new ServiceBusClient(
                "<NAMESPACE-NAME>.servicebus.windows.net",
                new DefaultAzureCredential(),
                clientOptions);
            sender = client.CreateSender("<QUEUE-NAME>");

            // create a batch 
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            for (int i = 1; i <= numOfMessages; i++)
            {
                // try adding a message to the batch
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                {
                    // if it is too large for the batch
                    throw new Exception($"The message {i} is too large to fit in the batch.");
                }
            }

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus queue
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch of {numOfMessages} messages has been published to the queue.");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }

            Console.WriteLine("Press any key to end the application");
            Console.ReadKey();
        }
        */
    }
}

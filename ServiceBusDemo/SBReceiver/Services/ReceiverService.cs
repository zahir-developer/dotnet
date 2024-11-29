using Microsoft.Extensions.Configuration;
using Azure.Messaging.ServiceBus;
using SBShared.Models;
using System.Text;
using System.Text.Json;

namespace SBReceiver
{
    public class ReceiverService : IReceiverService
    {
        private readonly IConfiguration _config;

        private readonly string queueName;

        private ServiceBusClient _client;

        private ServiceBusProcessor _processor;

        public ReceiverService(IConfiguration config)
        {
            _config = config;
            queueName = config["ServiceBusQueue:PersonQueue"].ToString();
        }

        public async Task ReceiveMessage()
        {
            var clientOption = new ServiceBusClientOptions()
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets,
                RetryOptions = new ServiceBusRetryOptions
                {
                    MaxRetries = 3
                }
            };
            _client = new ServiceBusClient(_config.GetConnectionString("AzureServiceBus"), clientOption);

            _processor = _client.CreateProcessor(queueName);

            try
            {
                //adding handler to process message
                _processor.ProcessMessageAsync += MessageHandler;

                //adding handler to process for errors if any.
                _processor.ProcessErrorAsync += ErrorHandler;

                //starting processing
                await _processor.StartProcessingAsync();

                Console.ReadKey();

                Console.WriteLine("Enter any keys to stop the processing...");
                
                //stop processing
                await _processor.StopProcessingAsync();


            }
            finally 
            {
                await _processor.DisposeAsync();
                await _client.DisposeAsync();
            }
        }

        async Task MessageHandler (ProcessMessageEventArgs args)
        {
            string json = Encoding.UTF8.GetString(args.Message.Body);
            var person = JsonSerializer.Deserialize<PersonModel>(json);
            Console.WriteLine($"Received detail of the person: {person.FirstName + " " + person.LastName}");
            //Complet the message, Message will be deleted from the queue.
            await args.CompleteMessageAsync(args.Message);
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"Message handler exception: {args.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}



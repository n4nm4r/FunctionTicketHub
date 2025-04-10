using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FunctionTicketHub
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function1))]
        public void Run([QueueTrigger("tickethub", Connection = "AzureWebJobsStorage")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");

            
            string messageJson = message.MessageText;

            //Deserialze message

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Ticket? ticket = JsonSerializer.Deserialize<Ticket>(messageJson, options);


            if (ticket == null) 
            {
                _logger.LogError("Failed to deserialize the message");
                return;
            }

            _logger.LogInformation($"Ticket:{ticket.Name}, " +
                $"\n{ticket.Email}" +
                $"\n{ticket.Phone}" +
                $"\n{ticket.Quantity}" +
                $"\n{ticket.CreditCard}" +
                $"\n{ticket.Expiration}" +
                $"\n{ticket.SecurityCode}" +
                $"\n{ticket.Address}" +
                $"\n{ticket.City}" +
                $"\n{ticket.Province}" +
                $"\n{ticket.PostalCode}" +
                $"\n{ticket.Country}");

            //add to database


        }
    }
}

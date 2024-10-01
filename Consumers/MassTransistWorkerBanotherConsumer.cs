namespace Company.Consumers
{
    using System;
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;
    using Microsoft.Extensions.Logging;

    public class MassTransistWorkerBanotherConsumer :
        IConsumer<TransactionStep2>
    {
        private readonly ILogger<TransactionStep2> _logger;

        public MassTransistWorkerBanotherConsumer(ILogger<TransactionStep2> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TransactionStep2> context)
        {
            _logger.LogInformation("Received Text Banother: {Text}", context.Message.Value);
            throw new Exception("boom!");
            //return Task.CompletedTask;
        }
    }
}

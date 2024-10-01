namespace Company.Consumers
{
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;
    using Microsoft.Extensions.Logging;

    public class MassTransistWorkerAnotherConsumer :
        IConsumer<TransactionStep1>
    {
        private readonly ILogger<TransactionStep1> _logger;

        public MassTransistWorkerAnotherConsumer(ILogger<TransactionStep1> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TransactionStep1> context)
        {
            _logger.LogInformation("Received Text Another: {Text}", context.Message.Value);
            return Task.CompletedTask;
        }
    }
}

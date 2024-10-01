namespace Company.Consumers
{
    using System;
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;
    using Microsoft.Extensions.Logging;

    public class MassTransistWorkerConsumer :
        IConsumer<TransactionStep1>
    {
        private readonly ILogger<TransactionStep1> _logger;
        private readonly IBus _bus;

        public MassTransistWorkerConsumer(ILogger<TransactionStep1> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<TransactionStep1> context)
        {
            _logger.LogInformation("Received Text: {Text}", context.Message.Value);
            try
            {
                await _bus.Publish(
                    new TransactionStep2
                    {
                        Value = $"The time is {DateTimeOffset.Now}",
                    });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

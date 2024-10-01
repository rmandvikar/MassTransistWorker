namespace Company.Consumers
{
    using MassTransit;

    public class MassTransistWorkerAnotherConsumerDefinition :
        ConsumerDefinition<MassTransistWorkerAnotherConsumer>
    {
        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MassTransistWorkerAnotherConsumer> consumerConfigurator,
            IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

            endpointConfigurator.UseInMemoryOutbox(context);
        }
    }
}

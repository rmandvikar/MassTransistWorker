namespace Company.Consumers
{
    using MassTransit;

    public class MassTransistWorkerBanotherConsumerDefinition :
        ConsumerDefinition<MassTransistWorkerBanotherConsumer>
    {
        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MassTransistWorkerBanotherConsumer> consumerConfigurator,
            IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

            endpointConfigurator.UseInMemoryOutbox(context);
        }
    }
}

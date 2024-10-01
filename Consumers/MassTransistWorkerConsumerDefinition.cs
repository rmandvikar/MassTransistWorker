namespace Company.Consumers
{
    using MassTransit;

    public class MassTransistWorkerConsumerDefinition :
        ConsumerDefinition<MassTransistWorkerConsumer>
    {
        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MassTransistWorkerConsumer> consumerConfigurator,
            IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

            endpointConfigurator.UseInMemoryOutbox(context);
        }
    }
}

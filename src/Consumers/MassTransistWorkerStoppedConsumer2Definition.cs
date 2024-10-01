using MassTransit;

namespace Company.Consumers;

public class MassTransistWorkerStoppedConsumer2Definition :
	ConsumerDefinition<MassTransistWorkerStoppedConsumer2>
{
	protected override void ConfigureConsumer(
		IReceiveEndpointConfigurator endpointConfigurator,
		IConsumerConfigurator<MassTransistWorkerStoppedConsumer2> consumerConfigurator,
		IRegistrationContext context)
	{
		endpointConfigurator.UseInMemoryOutbox(context);
	}
}

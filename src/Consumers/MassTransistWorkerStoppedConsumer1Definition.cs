using MassTransit;

namespace Company.Consumers;

public class MassTransistWorkerStoppedConsumer1Definition :
	ConsumerDefinition<MassTransistWorkerStoppedConsumer1>
{
	protected override void ConfigureConsumer(
		IReceiveEndpointConfigurator endpointConfigurator,
		IConsumerConfigurator<MassTransistWorkerStoppedConsumer1> consumerConfigurator,
		IRegistrationContext context)
	{
		endpointConfigurator.UseInMemoryOutbox(context);
	}
}

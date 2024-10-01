using MassTransit;

namespace Company.Consumers;

public class MassTransistWorkerStep2ConsumerDefinition :
	ConsumerDefinition<MassTransistWorkerStep2Consumer>
{
	protected override void ConfigureConsumer(
		IReceiveEndpointConfigurator endpointConfigurator,
		IConsumerConfigurator<MassTransistWorkerStep2Consumer> consumerConfigurator,
		IRegistrationContext context)
	{
		endpointConfigurator.UseInMemoryOutbox(context);
	}
}

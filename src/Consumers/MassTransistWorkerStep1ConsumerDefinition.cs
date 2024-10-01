using MassTransit;

namespace Company.Consumers;

public class MassTransistWorkerStep1ConsumerDefinition :
	ConsumerDefinition<MassTransistWorkerStep1Consumer>
{
	protected override void ConfigureConsumer(
		IReceiveEndpointConfigurator endpointConfigurator,
		IConsumerConfigurator<MassTransistWorkerStep1Consumer> consumerConfigurator,
		IRegistrationContext context)
	{
		endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

		endpointConfigurator.UseInMemoryOutbox(context);
	}
}

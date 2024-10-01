using MassTransit;

namespace Company.Consumers;

public class MassTransistWorkerSagaDefinition :
	ConsumerDefinition<MassTransistWorkerSaga>
{
	protected override void ConfigureConsumer(
		IReceiveEndpointConfigurator endpointConfigurator,
		IConsumerConfigurator<MassTransistWorkerSaga> consumerConfigurator,
		IRegistrationContext context)
	{
		endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

		endpointConfigurator.UseInMemoryOutbox(context);
	}
}

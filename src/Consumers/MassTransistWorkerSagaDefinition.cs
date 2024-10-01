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
		endpointConfigurator.UseInMemoryOutbox(context);
	}
}

using System;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Company.Consumers;

public class MassTransistWorkerSaga(ILogger<MassTransistWorkerSaga> logger, IBus bus) :
	IConsumer<TransactionStarted>,
	IConsumer<TransactionStep1Result>,
	IConsumer<TransactionStep2Result>
{
	public async Task Consume(ConsumeContext<TransactionStarted> context)
	{
		logger.LogInformation("Received Text: {type} {Text}", context.Message.GetType(), context.Message.Value);

		await bus.Publish(
			new TransactionStep1
			{
				Value = $"The time is {DateTimeOffset.Now}",
			});
	}

	public async Task Consume(ConsumeContext<TransactionStep1Result> context)
	{
		logger.LogInformation("Received Text: {type} {Text}", context.Message.GetType(), context.Message.Value);

		await bus.Publish(
			new TransactionStep2
			{
				Value = $"The time is {DateTimeOffset.Now}",
			});
	}

	public async Task Consume(ConsumeContext<TransactionStep2Result> context)
	{
		logger.LogInformation("Received Text: {type} {Text}", context.Message.GetType(), context.Message.Value);

		logger.LogInformation("Staring out of band");

		await bus.Publish(
			new TransactionStopped
			{
				Value = $"The time is {DateTimeOffset.Now}",
			});

		await Task.Yield();

		logger.LogInformation("Done");
	}
}

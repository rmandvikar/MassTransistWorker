using System;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Company.Consumers;

public class MassTransistWorkerStep1Consumer(ILogger<MassTransistWorkerStep1Consumer> logger, IBus bus) :
	IConsumer<TransactionStep1>
{
	public async Task Consume(ConsumeContext<TransactionStep1> context)
	{
		logger.LogInformation("Received Text: {type} {Text}", context.Message.GetType(), context.Message.Value);

		await bus.Publish(
			new TransactionStep1Result
			{
				Value = $"The time is {DateTimeOffset.Now}",
			});
	}
}

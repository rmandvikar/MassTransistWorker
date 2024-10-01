using System;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Company.Consumers;

public class MassTransistWorkerStep2Consumer(ILogger<TransactionStep2> logger, IBus bus) :
	IConsumer<TransactionStep2>
{
	public async Task Consume(ConsumeContext<TransactionStep2> context)
	{
		logger.LogInformation("Received Text: {type} {Text}", context.Message.GetType(), context.Message.Value);

		await bus.Publish(
			new TransactionStep2Result
			{
				Value = $"The time is {DateTimeOffset.Now}",
			});
	}
}

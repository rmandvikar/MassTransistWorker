using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Company.Consumers;

public class MassTransistWorkerStoppedConsumer1(ILogger<TransactionStopped> logger) :
	IConsumer<TransactionStopped>
{
	public async Task Consume(ConsumeContext<TransactionStopped> context)
	{
		logger.LogInformation("Received Text: {type} {Text}", context.Message.GetType(), context.Message.Value);

		logger.LogInformation("Doing out of band work");

		await Task.Yield();
	}
}

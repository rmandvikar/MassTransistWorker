using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace MassTransistWorker;

public class Worker(IBus bus) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			await bus.Publish(
				new TransactionStarted
				{
					Value = $"The time is {DateTimeOffset.Now}",
				},
				stoppingToken);

			await Task.Delay(1000, stoppingToken);

			break;
		}
	}
}

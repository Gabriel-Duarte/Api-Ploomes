using ApiPloomes.Application.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Application.Events
{
	public class LogEventHandler :
		
					INotificationHandler<ErrorNotification>
	{

		public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
			});
		}
	}
}

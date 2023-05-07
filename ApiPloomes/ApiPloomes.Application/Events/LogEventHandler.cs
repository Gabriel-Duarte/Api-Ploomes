using ApiPloomes.Application.Notifications;
using MediatR;

namespace ApiPloomes.Application.Events
{
	public class LogEventHandler : INotificationHandler<ErrorNotification>
	{
		public Task Handle(ProductActionNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"Nome: {notification.Name} \n Descrição:{notification.Description}\n Preço:{notification.Price} \n Image Url:{notification.ImageUrl}  " +
					$" \n Estoque:{notification.Stock} \n CategoriaId:{notification.CategoryId} \n Ação{notification.Action.ToString().ToLower()} successfuly");
			});
		}

		public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
			});
		}
	}
}

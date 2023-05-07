using MediatR;

namespace ApiPloomes.Application.Notifications
{
	public class ErrorNotification : INotification
	{
		public string Error { get; set; }
		public string Stack { get; set; }
	}
}

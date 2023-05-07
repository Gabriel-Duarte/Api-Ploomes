using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Application.Notifications
{
	public class CategoriesActionNotification : INotification
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public ActionNotification Action { get; set; }
	}
}

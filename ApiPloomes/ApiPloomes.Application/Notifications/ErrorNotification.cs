﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Application.Notifications
{
	public class ErrorNotification : INotification
	{
		public string Error { get; set; }
		public string Stack { get; set; }
	}
}

﻿namespace ApiPloomes.API.Communication
{
	public class ResponseSuccess
	{
		public bool IsSuccess { get; }
		public object? Data { get; }

		public ResponseSuccess(object? data, bool isSuccess = true)
		{
			IsSuccess = isSuccess;
			Data = data;
		}
	}
}
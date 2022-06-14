using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace HemsTask.Middleware
{
	public static class GlobalExceptionMiddleware
	{
		public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionHandler>();
		}

		public class ExceptionHandler
		{
			private readonly RequestDelegate _next;

			public ExceptionHandler(RequestDelegate next)
			{
				_next = next;
			}

			public async Task InvokeAsync(HttpContext httpContext)
			{
				try
				{
					await _next(httpContext);
				}
				catch (Exception ex)
				{
					await HandleGlobalExceptionAsync(httpContext, ex);
				}
			}

			private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
			{
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				return context.Response.WriteAsync
					(JsonConvert.SerializeObject(new { context.Response.StatusCode, exception.Message }));
			}
		}
	}
}

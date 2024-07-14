
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;

namespace ECommerce.Ploto.WebAPI.Middlewares;

public class ErrorHandlerMiddleware 
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
		try
		{
			await _next(context);
		}
		catch (Exception exception)
        {
            var currentResponse  = context.Response;
            object response;
            int statusCode;

            switch (currentResponse.StatusCode)
            {
                case StatusCodes.Status401Unauthorized:
                    response = new { message = "Unauthorized access." };
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                case StatusCodes.Status400BadRequest:
                    response = new { message = "Request Is Not Valid" };
                    statusCode = StatusCodes.Status400BadRequest;

                    break;
                case StatusCodes.Status404NotFound:
                    response = new { message = "server cannot find the requested resourcet" };
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                case StatusCodes.Status429TooManyRequests:
                    response = new { message = "you requests are limited" };
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                default:
                    response = new { message =  exception.Message ?? "An error occurred while processing your request" };
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(response);
		}
    }
}

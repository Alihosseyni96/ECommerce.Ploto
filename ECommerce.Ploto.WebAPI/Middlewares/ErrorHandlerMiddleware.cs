
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Polly.CircuitBreaker;
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
            


            switch (exception)
            {
                case UnauthorizedAccessException:
                    response = new { message = "Unauthorized access." };
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                case BadHttpRequestException:
                    response = new { message = "Request Is Not Valid" };
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case DirectoryNotFoundException:
                    response = new { message = "server cannot find the requested resourcet" };
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                case BrokenCircuitException:
                    response = new { message = "service is unavailable. try again later" };
                    statusCode = StatusCodes.Status503ServiceUnavailable;
                    break;
                default :
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

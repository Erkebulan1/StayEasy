using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StayEasy.Service.Excepsions;
using StayEasy.MobileApi.Models;
using Response = StayEasy.MobileApi.Models.Response;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundException ex)
        {
            httpContext.Response.StatusCode = ex.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message
            });
        }
        catch (AlreadyExistException ex)
        {
            httpContext.Response.StatusCode = ex.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message
            });
        }
        catch (ArgumentIsNotValidException ex)
        {
            httpContext.Response.StatusCode = ex.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = 500,
                Message = "Server error occurred"
            });

            _logger.LogError(ex, ex.Message);
        }
    }
}
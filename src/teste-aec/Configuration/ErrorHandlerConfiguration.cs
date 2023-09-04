using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Text.Json;
using TestAec.DbContexts;
using TestAec.Models.Errors;

namespace TestAec.Configuration;
public static class ErrorHandlerConfiguration
{
    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(new ExceptionHandlerOptions
        {
            ExceptionHandlingPath = new PathString("/Error"),
            AllowStatusCode404Response = true
        });
    }
    public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source,
        Func<TSource, TSource> nextItem,
        Func<TSource, bool> canContinue)
    {
        for (var current = source; canContinue(current); current = nextItem(current))
        {
            yield return current;
        }
    }
    public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source,
       Func<TSource, TSource> nextItem) where TSource : class
    {
        return FromHierarchy(source, nextItem, s => s != null);
    }
    public static IEnumerable<ErrorMessage> GetAllMessages(this Exception exception)
    {
        var messages = exception.FromHierarchy(ex => ex.InnerException)
            .Select(ex => new ErrorMessage(ex.Message));
        return messages;
    }
    public static string GetAllMessage(this Exception exception)
    {
        var messages = exception.FromHierarchy(ex => ex.InnerException)
            .Select(ex => new ErrorMessage(ex.Message));
        return string.Join(", ", messages);
    }
}
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ErrorHandlingMiddleware> logger)
    {
        _requestDelegate = requestDelegate;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            await HandlerExceptionAsync(context, ex);
        }
    }
    private Task HandlerExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "ErrorHandlingMiddleware - Falha não tratada");
        var errors = exception.GetAllMessages();
        context.Response.StatusCode = 400;
        return context.Response.WriteAsJsonAsync(errors);
    }
}
public class ExceptionHandler : ControllerBase
{
    private readonly ApiContext _context;
    public ExceptionHandler(ApiContext context)
    {
        _context = context;
    }
    public const string INTERNAL_SERVER_ERROR = "Erro ao processar a requisição";
    [HttpGet("Error")]
    public async Task< IActionResult> Error()
    {
        var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;
        var errors = ex.GetAllMessages();
        _context.AddRange(errors);
        await _context.SaveChangesAsync();
        return BadRequest(errors);
    }
}


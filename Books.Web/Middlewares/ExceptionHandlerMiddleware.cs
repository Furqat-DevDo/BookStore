using Books.Web.Models;

namespace Books.Web.Middlewares;

public class ExceptionHandlerMiddleware  : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
          await next.Invoke(context);
        }
        catch (Exception ex)
        {
            var errorViewModel = new ErrorViewModel
            {
                Path = context.Request.Path,
                Messages = new List<string> { ex.Message }
            };
            var queryString = $"path={Uri.EscapeDataString(errorViewModel.Path)}&errorMessages={Uri.EscapeDataString(ex.Message)}";
            var redirectUrl = $"/Error?{queryString}";

            context.Response.Redirect(redirectUrl);
        }
    }
}
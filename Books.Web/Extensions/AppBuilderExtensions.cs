using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Books.Web.Extensions;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder UseLocalization(this IApplicationBuilder app)
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("ru-RU"),
            new CultureInfo("uz-Latn")
        };

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("uz-Latn"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        return app;
    }
}
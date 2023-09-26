using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class RootController : Controller
{
    public IActionResult ChangeCulture(string culture,string returnUrl)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions{Expires = DateTimeOffset.Now.AddHours(30)});
        return LocalRedirect(returnUrl);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListGenerator.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ListGenerator.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        public IActionResult SetCulture(string culture)
        {
            if (culture != null)
            {
                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(
                        new RequestCulture(culture)));
            }

            var a = new BaseResponse()
            {
                IsSuccess = true
            };

            return Ok(a);
        }
    }
}

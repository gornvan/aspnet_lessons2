using FabricMarket_MVC.Filters;
using FabricMarket_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FabricMarket_MVC.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IConfiguration config) : base(config)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var response = await ForwardLoginRequest(model);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(nameof(model.Password), "Failed to authenticate, please chek Email and/or Password");
                    // Handle unsuccessful login from API
                    return View(model);
                }

                var cookies = ExtractCookiesFromResponse(response);

                // Set cookies to the response to return to the client
                foreach (var cookie in cookies)
                {
                    Response.Cookies.Append(cookie.Key, cookie.Value, new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(1), // Set expiration as needed
                        HttpOnly = true // Ensure cookies are only accessible via HTTP
                    });
                }

                // Also set the Email as a Cookie:
                Response.Cookies.Append(CurrentUserFromCookieFilterAttribute.UserNameCookieKey, model.Email, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(1), // Set expiration as needed
                    HttpOnly = true // Ensure cookies are only accessible via HTTP
                });

                var returnUrl = Url.Action(nameof(HomeController.Index), "Home");
                if (Url.IsLocalUrl(model.ReturnPath))
                {
                    returnUrl = model.ReturnPath;
                }

                return Redirect(returnUrl);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private async Task<HttpResponseMessage> ForwardLoginRequest(LoginViewModel model)
        {
            var httpClient = new HttpClient();

            var loginUrl = ApiBaseUrl + "/api/login"; // Adjust the API endpoint accordingly
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Forward the login request to the base API URL
            return await httpClient.PostAsync(loginUrl, content);
        }

        private IDictionary<string, string> ExtractCookiesFromResponse(HttpResponseMessage response)
        {
            var cookies = new Dictionary<string, string>();

            IEnumerable<string> cookieValues;
            if (response.Headers.TryGetValues("Set-Cookie", out cookieValues))
            {
                foreach (var cookie in cookieValues)
                {
                    var cookieParts = cookie.Split(';')[0].Split('=');
                    if (cookieParts.Length == 2)
                    {
                        cookies.Add(cookieParts[0], cookieParts[1]);
                    }
                }
            }

            return cookies;
        }
    }
}

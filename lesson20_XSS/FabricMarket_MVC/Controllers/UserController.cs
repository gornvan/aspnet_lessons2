
using FabricMarket_BLL.Contracts.Identity;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FabricMarket_MVC.Controllers
{
	public class UserController : BaseController
	{
		public UserController(IConfiguration config) : base(config)
		{
		}

		public async Task<ViewResult> ListView(string search, int skip=0, int take=10)
		{
            string UsersEnpointPath = "api/User";

            try
            {
                using (var client = CreateApiClient())
                {
                    // Construct the query parameters
                    string url = $"{ApiBaseUrl}/{UsersEnpointPath}?skip={skip}&take={take}&s={search}";

                    // Send the GET request and retrieve the response
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    var users = await ParseJsonBody<List<UserBriefModel>>(response);

                    return View(users);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle any HTTP request errors
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
		}
	}
}

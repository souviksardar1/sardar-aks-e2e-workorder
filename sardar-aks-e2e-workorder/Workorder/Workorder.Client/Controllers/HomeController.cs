using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Workorder.Client.Models;

namespace Workorder.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client.CreateClient("LaborAPIUrl");
        }

        public async Task<IActionResult> Index()
        {
            //HttpRequestMessage request = new HttpRequestMessage();
            //request.Method = HttpMethod.Get;
            ////request.RequestUri = new Uri("http://localhost:5000/Product");
            //request.RequestUri = new Uri("http://host.docker.internal:5000/Product");
            //var httpClient1 = new HttpClient();
            //var response = await httpClient1.SendAsync(request);
            //if (response.IsSuccessStatusCode)
            //{

            //}

            var response = await _client.GetAsync("/api/Labors");
            var content = response.Content.ReadAsStringAsync();
            var labors = JsonConvert.DeserializeObject<IEnumerable<Labor>>(content.Result);
            return View(labors);
        }
    }
}
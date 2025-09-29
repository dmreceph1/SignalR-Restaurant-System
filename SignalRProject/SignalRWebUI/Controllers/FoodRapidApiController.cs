using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.RapidApiDtos;
using System.Net.Http.Headers;
namespace SignalRWebUI.Controllers
{
    public class FoodRapidApiController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<ResultTastyApi> resultTastyApis = new List<ResultTastyApi>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "2ee648b697mshec4dba54e1921d5p1c45c2jsn5f9c1222ee73" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //resultTastyApis = JsonConvert.DeserializeObject<List<ResultTastyApi>>(body);
                //return View(resultTastyApis);
                var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values = root.Results;
                return View(values.ToList());
            }
        }
    }
}

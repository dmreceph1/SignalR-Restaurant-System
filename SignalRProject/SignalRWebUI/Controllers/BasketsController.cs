using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync("https://localhost:7120/api/Basket/BasketListByMenuTableWithProductName?id="+id);
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData = await responMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            //id = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7120/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var menuTableId = TempData["id"];
                return RedirectToAction("Index", new { id = menuTableId });
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int menuTableId, string tableName)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:7120/api/Orders/Checkout?menuTableId={menuTableId}&tableName={Uri.EscapeDataString(tableName ?? string.Empty)}", null);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return RedirectToAction("Index", new { id = menuTableId });
        }
    }
}

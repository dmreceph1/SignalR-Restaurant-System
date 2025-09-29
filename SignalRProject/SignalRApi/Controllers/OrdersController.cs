using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Businesslayer.Abstract;
using SignalR.DataAccesslayer.Concrete;
using SignalR.EntityLayer.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IMenuTableService _menuTableService;
        private readonly INotificationService _notificationService;

        public OrdersController(IOrderService orderService, IBasketService basketService, IMenuTableService menuTableService, INotificationService notificationService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _menuTableService = menuTableService;
            _notificationService = notificationService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        [HttpGet("TodayOrderDal")]
        public IActionResult TodayOrderDal()
        {
            return Ok(_orderService.TTodayOrderDal());
        }

        // POST api/Orders/Checkout?menuTableId=5&tableName=Masa-5
        [HttpPost("Checkout")]
        public IActionResult Checkout(int menuTableId, string tableName)
        {
            using var context = new SignalRContext();
            var basketItems = context.Baskets.Include(x => x.Product).Where(x => x.MenuTableID == menuTableId).ToList();
            if (basketItems == null || basketItems.Count == 0)
            {
                return BadRequest("Sepet boş");
            }

            var subtotal = basketItems.Sum(x => (x.Price > 0 ? x.Price : 0) * (x.Count > 0 ? x.Count : 1));
            var tax = subtotal * 0.10m;
            var total = subtotal + tax;

            // Menü masası adını veritabanından al
            var resolvedTableName = context.MenuTables
                .Where(mt => mt.MenuTableID == menuTableId)
                .Select(mt => mt.Name)
                .FirstOrDefault();
            if (string.IsNullOrWhiteSpace(resolvedTableName))
            {
                resolvedTableName = string.IsNullOrWhiteSpace(tableName) ? ($"Masa-{menuTableId}") : tableName;
            }

            var order = new Order
            {
                TableNumber = resolvedTableName,
                Description = "Hesap Kapatıldı",
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                TotalPrice = total
            };
            // Siparişi ekle + sepeti boşalt (tek SaveChanges ile atomik)
            context.Orders.Add(order);
            context.Baskets.RemoveRange(basketItems);
            context.SaveChanges();

            // Masa durumunu false (boş) yap
            _menuTableService.TChangeMenuTableStatusToFalse(menuTableId);

            // Bildirim oluştur: sepet içeriği özeti
            var contentSummary = string.Join(
                ", ",
                basketItems
                    .GroupBy(b => new { b.productID, Name = b.Product != null ? b.Product.ProductName : context.Products.Where(p => p.ProductID == b.productID).Select(p => p.ProductName).FirstOrDefault() })
                    .Select(g => ($"{g.Sum(x => (x.Count > 0 ? x.Count : 1))} {g.Key.Name}"))
            );

            var notification = new Notification
            {
                Type = "Yeni Sipariş",
                Icon = "fa fa-shopping-basket",
                Description = $"Yeni yemek siparişi - {resolvedTableName}: {contentSummary}",
                Date = DateTime.Now,
                Status = false
            };
            _notificationService.TAdd(notification);

            return Ok(new { message = "Sipariş oluşturuldu", orderId = order.OrderID, subtotal, tax, total });
        }
    }
}

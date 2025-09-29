using Microsoft.AspNetCore.SignalR;
using SignalR.Businesslayer.Abstract;
using SignalR.DataAccesslayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendIstastisc()
        {
            var ReciveCategoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReciveCategoryCount", ReciveCategoryCount);

            var ReciveProductCount = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReciveProductCount", ReciveProductCount);

            var ReciveActiveCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReciveActiveCategoryCount", ReciveActiveCategoryCount);

            var RecivePassiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("RecivePassiveCategoryCount", RecivePassiveCategoryCount);

            var ExpensiveProduct = _productService.ProductNameByMaxPrice();
            await Clients.All.SendAsync("ReciveExpensivePrdouct", ExpensiveProduct);

            var ChepperProduct = _productService.ProductNameByMinPrice();
            await Clients.All.SendAsync("ReciveCheaperPrdouct", ChepperProduct);

            var TotalOrder = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReciveTotelOrder", TotalOrder);

            var ActiveOrder = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReciveActiveOrder", ActiveOrder);

            var LastOrder = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReciveLastOrder", LastOrder);

            var MoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReciveMoneyCase", MoneyCaseAmount);

            var TodayProfit = _orderService.TTodayOrderDal();
            await Clients.All.SendAsync("ReciveTodayProfit", TodayProfit);

            var TableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReciveTableCount", TableCount);
        }

        public async Task SendProgress()
        {
            var ReciveMoneyCase = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReciveMoneyCase", ReciveMoneyCase.ToString("0.00" + "₺"));

            var ActiveOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReciveActiveOrderCount", ActiveOrderCount);

            var MenuActive = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReciveMenuActive", MenuActive);

            var GetRateForMenuTables = _menuTableService.TTableRateToAll();
            await Clients.All.SendAsync("ReciveMenuTablesRateProggres", GetRateForMenuTables);
        }


        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReciveBookingList", values);
        }


        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var ActiveNotificationList = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReciveActiveList", ActiveNotificationList);
        }

        public async Task GetMenuTablesStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReciveMenuTableStatus", value);
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponents:ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

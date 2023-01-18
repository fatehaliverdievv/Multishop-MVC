using Microsoft.AspNetCore.Mvc;

namespace Multishop.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

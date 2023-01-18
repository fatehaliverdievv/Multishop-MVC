using Microsoft.AspNetCore.Mvc;

namespace Multishop.Areas.Manage.Controllers
{
        [Area("Manage")]
    public class ColorController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

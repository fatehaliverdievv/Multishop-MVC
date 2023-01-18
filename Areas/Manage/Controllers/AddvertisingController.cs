using Microsoft.AspNetCore.Mvc;

namespace Multishop.Areas.Manage.Controllers
{
    public class AddvertisingController:Controller
    {
        [Area("Manage")]
        public ActionResult Index()
        {
            return View();
        }
    }
}

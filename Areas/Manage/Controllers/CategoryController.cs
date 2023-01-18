using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Multishop.Areas.Manage.Controllers
{
        [Area("Manage")]
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

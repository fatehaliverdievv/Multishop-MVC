using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Multishop.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DiscountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

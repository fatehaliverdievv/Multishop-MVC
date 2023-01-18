using Microsoft.AspNetCore.Mvc;
using Multishop.Models;
using System.Diagnostics;

namespace Multishop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
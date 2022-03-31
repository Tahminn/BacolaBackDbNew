using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Cart";
            ViewBag.Javascript = "cart";
            return View();
        }
    }
}

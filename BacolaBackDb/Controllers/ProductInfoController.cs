using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Controllers
{
    public class ProductInfoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Product Info";
            ViewBag.Javascript = "product-info";
            return View();
        }
    }
}

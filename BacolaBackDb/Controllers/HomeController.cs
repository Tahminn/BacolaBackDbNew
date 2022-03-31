using BacolaBackDb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BacolaBackDb.Models;
using Microsoft.Extensions.Logging;
using BacolaBackDb.Models.Home;
using BacolaBackDb.ViewModels;
using Newtonsoft.Json;

namespace BacolaBackDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Products
        
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .OrderByDescending(m => m.Id)
                .Take(20)
                .ToListAsync();
            List<Category> categories = await _context.Categories
                .Where(p => p.IsDeleted == false)
                .ToListAsync();
            List<Slider> sliders = await _context.Sliders
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            if (Request.Cookies["basket"] != null)
            {
                HomeVM homeVM = new HomeVM
                {
                    Products = products,
                    Categories = categories,
                    Sliders = sliders,
                    BasketVM = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"])
                };
                return View(homeVM);
            }
            else
            {
                HomeVM homeVM = new HomeVM
                {
                    Products = products,
                    Categories = categories,
                    Sliders = sliders
                };
                return View(homeVM);
            }
            

            
        }
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id is null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return BadRequest();
            List<BasketVM> basket;

            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }
            var existProduct = basket.Find(m => m.Id == dbProduct.Id);
            if (existProduct is null)
            {
                basket.Add(new BasketVM
                {
                    Id = dbProduct.Id,
                    Count = 1
                });
            }
            else
            {
                existProduct.Count++;
            }



            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return RedirectToAction("Index", "Home");
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            List<Category> categories = await _context.Categories
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            if (Request.Cookies["basket"] != null)
            {
                HomeVM homeVM = new HomeVM
                {
                    Product = product,
                    Categories = categories,
                    BasketVM = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"])
                };
                return View(homeVM);
            }
            else
            {
                HomeVM homeVM = new HomeVM
                {
                    Product = product,
                    Categories = categories,
                };
                return View(homeVM);
            }
        }
    }
}

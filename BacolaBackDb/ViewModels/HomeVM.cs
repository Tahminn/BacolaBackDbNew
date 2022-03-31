using BacolaBackDb.Models.Home;
using FiorelloBackDb.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.ViewModels
{
    public class HomeVM
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<BasketVM> BasketVM { get; set; }
        public Product Product { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        //public List<ProductImage> ProductImages { get; set; }
    }
}

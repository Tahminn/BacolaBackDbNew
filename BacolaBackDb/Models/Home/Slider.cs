using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Models.Home
{
    public class Slider:BaseEntity
    {
        public string Image { get; set; }
        public string? Description { get; set; }
        [NotMapped,Required]
        public IFormFile Photo { get; set; }
    }
}

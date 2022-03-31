using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Models.Home
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Cart
    {
        public int CartId { get; set; } // Primary Key
        public int ProductId { get; set; } // Foreign Key
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Product? Product { get; set; }
    }
}

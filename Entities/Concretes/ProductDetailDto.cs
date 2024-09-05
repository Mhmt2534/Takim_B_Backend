using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ProductDetailDto
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string categoryName { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }
        public long Barcode { get; set; }

    }
}

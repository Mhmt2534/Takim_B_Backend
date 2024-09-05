using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService:IGenericService<Product>
    {
        public Task<Product> GetByName(string name);
        public Task<Product> GetByBarcode(long barcode);
        public Task<List<ProductDetailDto>> GetProductDetail(string categoryName);
        public Task<List<ProductDetailDto>> GetAllProductDetail();

    }
}

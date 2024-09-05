using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        public  Task<Product> GetByName(string name);
        public  Task<Product> GetByBarcode(long barcode);
        public Task<List<ProductDetailDto>> GetProductDetail(string categoryName);
        public Task<List<ProductDetailDto>> GetAllProductDetail();

    }
}

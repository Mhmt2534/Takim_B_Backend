using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly MutluMarketDb _context;
        public ProductRepository(IGenericRepository<Product> genericRepository, MutluMarketDb context)
        {
            _genericRepository = genericRepository;
            _context = context;

        }

        public void AddEntity(Product entity)
        {
            _genericRepository.AddEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            _genericRepository.DeleteEntity(id);
        }

       
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<Product> GetByBarcode(long barcode)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Barcode == barcode);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<Product> GetByName(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ProductName == name);
        }

        public Task<List<ProductDetailDto>> GetProductDetail(string categoryName)
        {


            var result = from p in _context.Products
                         join c in _context.Categories
                         on p.CategoryId equals c.categoryId
                         where c.categoryName == categoryName
                         select new ProductDetailDto
                         {
                             productId = p.ProductId,
                             productName = p.ProductName,
                             categoryName = c.categoryName,
                             Price = p.Price,
                             UnitsInStock = p.UnitsInStock,
                             Barcode = p.Barcode
                         };
            return result.ToListAsync();

        }

        public Task<List<ProductDetailDto>> GetAllProductDetail()
        {


            var result = from p in _context.Products
                         join c in _context.Categories
                         on p.CategoryId equals c.categoryId
                         select new ProductDetailDto
                         {
                             productId = p.ProductId,
                             productName = p.ProductName,
                             categoryName = c.categoryName,
                             Price = p.Price,
                             UnitsInStock = p.UnitsInStock,
                             Barcode = p.Barcode
                         };
            return result.ToListAsync();

        }


        public void UpdateEntity(Product entity)
        {
            _genericRepository.UpdateEntity(entity);
        }
    }
}

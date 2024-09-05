using Business.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddEntity(Product entity)
        {
            _productRepository.AddEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            _productRepository.DeleteEntity(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByBarcode(long barcode)
        {
            return await _productRepository.GetByBarcode(barcode);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public Task<Product> GetByName(string name)
        {
            return _productRepository.GetByName(name);
        }

        public async Task<List<ProductDetailDto>> GetProductDetail(string categoryName)
        {
            return await _productRepository.GetProductDetail(categoryName);
        }

        public void UpdateEntity(Product entity)
        {
            _productRepository.UpdateEntity(entity);
        }

        public Task<List<ProductDetailDto>> GetAllProductDetail()
        {
            return _productRepository.GetAllProductDetail();
        }
    }
}

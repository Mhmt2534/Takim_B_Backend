using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ProductImageRepositroy : IProductImageRepository
    {
        private readonly IGenericRepository<ProductImage> _genericRepository;
        private readonly MutluMarketDb _context;
        public ProductImageRepositroy(IGenericRepository<ProductImage> genericRepository, MutluMarketDb context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }
        public void AddEntity(ProductImage entity)
        {
            _genericRepository.AddEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            _genericRepository.DeleteEntity(id);
        }


        public async void DeleteImage(ProductImage productImage)
        {
            _context.ProductImages.Remove(productImage);
            _context.SaveChanges();
        }



        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<ProductImage> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<ProductImage> GetByProductId(int id)
        {
            return await _context.ProductImages.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public void UpdateEntity(ProductImage entity)
        {
            _genericRepository.UpdateEntity(entity);
        }
    }
}

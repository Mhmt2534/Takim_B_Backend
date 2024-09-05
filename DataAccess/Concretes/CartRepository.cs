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
    public class CartRepository : ICartRepository
    {
        private readonly IGenericRepository<Cart> _genericRepository;
        private readonly MutluMarketDb _context;
        public CartRepository(IGenericRepository<Cart> genericRepository, MutluMarketDb context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }


        public void AddEntity(Cart entity)
        {
            _genericRepository.AddEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            _genericRepository.DeleteEntity(id);
        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            return _genericRepository.GetAllAsync();
        }

        public Task<Cart> GetByIdAsync(int id)
        {
            return _genericRepository.GetByIdAsync(id);
        }

        public async Task<Cart> GetByProductId(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public void UpdateEntity(Cart entity)
        {
            _genericRepository.UpdateEntity(entity);
        }
    }
}

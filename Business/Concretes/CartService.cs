using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddEntity(Cart entity)
        {
            _cartRepository.AddEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            _cartRepository.DeleteEntity(id);
        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            return _cartRepository.GetAllAsync();
        }

        public Task<Cart> GetByIdAsync(int id)
        {
            return _cartRepository.GetByIdAsync(id);
        }

        public async Task<Cart> GetByProductId(int id)
        {
            return await _cartRepository.GetByProductId(id);
        }

        public void UpdateEntity(Cart entity)
        {
            _cartRepository.UpdateEntity(entity);
        }
    }
}

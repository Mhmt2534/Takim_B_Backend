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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly MutluMarketDb _context;
        public CategoryRepository(IGenericRepository<Category> genericRepository, MutluMarketDb context)
        {
            _genericRepository = genericRepository;
            _context = context;

        }

        public void AddEntity(Category entity)
        {
            _genericRepository.AddEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            _genericRepository.DeleteEntity(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.categoryName == name);
        }

        public void UpdateEntity(Category entity)
        {
            _genericRepository.UpdateEntity(entity);
        }
    }
}

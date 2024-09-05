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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddEntity(Category category)
        {
            _categoryRepository.AddEntity(category);
        }

        public void DeleteEntity(int id)
        {
            _categoryRepository.DeleteEntity(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public Task<Category> GetByName(string name)
        {
            return _categoryRepository.GetByName(name);
        }

        public void UpdateEntity(Category category)
        {
            _categoryRepository.UpdateEntity(category);
        }
    }
}

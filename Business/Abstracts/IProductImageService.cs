using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImage>> GetAllAsync();
        Task<ProductImage> GetByIdAsync(int id);
        void AddEntity(IFormFile file, ProductImage entity);
        void UpdateEntity(IFormFile file, ProductImage entity);
        void DeleteImage(ProductImage productImage);
          Task<ProductImage> GetByProductId(int id);
    }
}

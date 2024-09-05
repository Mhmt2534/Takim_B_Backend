using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IProductImageRepository:IGenericRepository<ProductImage>
    {
        public void DeleteImage(ProductImage productImage);
        public  Task<ProductImage> GetByProductId(int id);
    }
}

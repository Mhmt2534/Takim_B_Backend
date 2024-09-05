using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService:IGenericService<Category>
    {
        public Task<Category> GetByName(string name);
    }
}

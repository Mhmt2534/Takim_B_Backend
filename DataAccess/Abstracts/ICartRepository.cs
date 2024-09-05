using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICartRepository:IGenericRepository<Cart>
    {
        public Task<Cart> GetByProductId(int id);

    }
}

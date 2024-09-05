using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IGenericRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(int id);


    }
}

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
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private readonly MutluMarketDb _context;
        public GenericRepository(MutluMarketDb context)
        {
            _context = context;
        }
        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges(); 
        }

        public void DeleteEntity(int id)
        {
            var entity = GetByIdAsync(id).Result;
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }


       
    }
}

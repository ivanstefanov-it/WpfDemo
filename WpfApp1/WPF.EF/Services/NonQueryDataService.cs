using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.EF.Services
{
    public class NonQueryDataService<T> where T : class
    {
        private readonly WpfDbContext _wpfDbContext;

        public NonQueryDataService(WpfDbContext wpfDbContext)
        {
            _wpfDbContext = wpfDbContext;
        }

        public async Task<T> Create(T entity)
        {
            EntityEntry<T> entityEntry = await _wpfDbContext.Set<T>().AddAsync(entity);
            await _wpfDbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<bool> Delete(T entity)
        {
            EntityEntry<T> entityEntry = _wpfDbContext.Set<T>().Remove(entity);
            await _wpfDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> Update(T entity)
        {
            EntityEntry<T> entityEntry = _wpfDbContext.Set<T>().Update(entity);
            await _wpfDbContext.SaveChangesAsync();
            return entity;
        }
    }
}

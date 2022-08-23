using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.domain.Services;

namespace WPF.EF.Services
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {
        private readonly WpfDbContext _wpfDbContext;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(WpfDbContext wpfDbContext)
        {
            _wpfDbContext = wpfDbContext;
            _nonQueryDataService = new NonQueryDataService<T>(wpfDbContext);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            return await _nonQueryDataService.Delete(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _wpfDbContext.Set<T>().FindAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _wpfDbContext.Set<T>().ToListAsync();
        }

        public Task<T> Update(T entity)
        {
            return _nonQueryDataService.Update(entity);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Core.DataInterface;
using Tasklist.Domain.Interface;

namespace Tasklist.Infraestructure.Generic
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T>, IDisposable where T : class
    {
        protected readonly TaskContext _context;
        private readonly DbContextOptions<TaskContext> _OptionsBuilder;
        public RepositoryGeneric()
        {
            _OptionsBuilder = new DbContextOptions<TaskContext>();
            _context = new TaskContext(_OptionsBuilder);
        }

        public IUnitOfWork IUnitOfWork => _context;

        public async Task Add(T Task)
        {
            await _context.Set<T>().AddAsync(Task);
            await _context.Commit();
        }

        public async Task<List<T>> ListAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<bool> Update(T Task)
        {
            _context.Set<T>().Update(Task);
            return await _context.Commit();

        }

        public async Task<T> GetById(Guid Id)
        {
          return await _context.Set<T>().FindAsync(Id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Core.DataInterface;

namespace Tasklist.Domain.Interface
{
    public interface IRepositoryGeneric<T> : IDisposable where T : class
    {
        Task Add(T Task);
        Task<bool> Update(T Task);
        Task<List<T>> ListAll();
        Task<T> GetById(Guid Id);
    }
}

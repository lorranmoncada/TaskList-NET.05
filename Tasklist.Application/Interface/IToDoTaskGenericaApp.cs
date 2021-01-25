using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasklist.Application.Interface
{
    public interface IToDoTaskGenericaApp<T> where T : class
    {
        Task Add(T Task);
        Task<bool> Update(T Task);
        Task<List<T>> ListAll();
        Task<T> GetById(Guid Id);
    }
}

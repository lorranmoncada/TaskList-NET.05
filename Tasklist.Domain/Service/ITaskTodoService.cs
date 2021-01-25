using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Domain.Model;

namespace Tasklist.Domain.Service
{
    public interface ITaskTodoService : IDisposable
    {
        Task CadastrarTask(ToDoTask task);
        Task EditarTask(ToDoTask task);
        Task<bool> InativarTask(ToDoTask task);
        Task<bool> ConcluirTask(ToDoTask task);
        Task<bool> PendenciarTask(ToDoTask task);
        Task<bool> ReativarTask(ToDoTask task);

    }
}

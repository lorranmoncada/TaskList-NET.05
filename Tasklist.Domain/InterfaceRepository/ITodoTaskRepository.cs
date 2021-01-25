using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Core.DataInterface;
using Tasklist.Domain.Model;

namespace Tasklist.Domain.Interface
{
    public interface ITodoTaskRepository : IRepositoryGeneric<ToDoTask>
    {
        Task<IEnumerable<ToDoTask>> ListarTodasTasksPendentes();
        Task<IEnumerable<ToDoTask>> ListTodasTasksConcluidas();
        Task<IEnumerable<ToDoTask>> ListTodasTasksInativas();

    }
}

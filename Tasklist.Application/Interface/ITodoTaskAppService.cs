using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Application.Interface;
using Tasklist.Domain.Model;

namespace Tasklist.Application.AppService
{
    public interface ITodoTaskAppService : IDisposable, IToDoTaskGenericaApp<ToDoTask>
    {
        Task<IEnumerable<ToDoTask>> ListarTodasTasksPendentes();

        Task<IEnumerable<ToDoTask>> ListarTodasTasksConcluidas();

        Task<IEnumerable<ToDoTask>> ListarTodasTasksInativas();

        Task<bool> InativarTask(ToDoTask Task);

        Task<bool> ConcluirTask(ToDoTask task);

        Task<bool> PendenciarTask(ToDoTask task);

        Task<bool> ReativarTask(ToDoTask task);

    }
}

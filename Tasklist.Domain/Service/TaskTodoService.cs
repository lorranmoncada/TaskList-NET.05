using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Core.DataObjects;
using Tasklist.Domain.Interface;
using Tasklist.Domain.Model;
using Tasklist.Domain.Service;

namespace Tasklist.Domain
{
    public class TaskTodoService : ITaskTodoService
    {
        private readonly ITodoTaskRepository _ITodoTaskRepository;
        public TaskTodoService(ITodoTaskRepository ITodoTaskRepository)
        {
            _ITodoTaskRepository = ITodoTaskRepository;
        }

        public async Task CadastrarTask(ToDoTask task)
        {
            if (task.Id == Guid.Empty) throw new DomainExeption("Id da task inexistente");

            task.CriarTaskStatus();
            task.AtivarTask();
            await _ITodoTaskRepository.Add(task);
        }

        public async Task<IEnumerable<ToDoTask>> ListTodasTasksPendentes()
        {
            return await _ITodoTaskRepository.ListarTodasTasksPendentes();
        }

        public async Task EditarTask(ToDoTask task)
        {
            await _ITodoTaskRepository.Update(task);
        }

        public async Task<bool> InativarTask(ToDoTask task)
        {
            task.AdicionarRemocao();
            task.DesativarTask();
            return await _ITodoTaskRepository.Update(task);
        }

        public async Task<bool> ConcluirTask(ToDoTask task)
        {
            task.FinalizarTaskStatus();
            return await _ITodoTaskRepository.Update(task);
        }

        public async Task<bool> PendenciarTask(ToDoTask task)
        {
            task.CriarTaskStatus();
            return await _ITodoTaskRepository.Update(task);
        }

        public async Task<bool> ReativarTask(ToDoTask task)
        {
            task.AtivarTask();
            return await _ITodoTaskRepository.Update(task);
        }

        public void Dispose()
        {
            _ITodoTaskRepository?.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Domain.Interface;
using Tasklist.Domain.Model;
using Tasklist.Domain.Service;

namespace Tasklist.Application.AppService
{
    public class ToDoTaskAppService : ITodoTaskAppService
    {
        private readonly ITodoTaskRepository _ITodoTaskRepository;
        private readonly ITaskTodoService _ITaskTodoService;

        public ToDoTaskAppService(ITodoTaskRepository ITodoTaskRepository, ITaskTodoService ITaskTodoService)
        {
            _ITodoTaskRepository = ITodoTaskRepository;
            _ITaskTodoService = ITaskTodoService;
        }
        public async Task Add(ToDoTask Task)
        {
            await _ITaskTodoService.CadastrarTask(Task);
        }

        public async Task<bool> InativarTask(ToDoTask Task)
        {
            return await _ITaskTodoService.InativarTask(Task);
        }

        public async Task<List<ToDoTask>> ListAll()
        {
            return await _ITodoTaskRepository.ListAll();
        }

        public async Task<IEnumerable<ToDoTask>> ListarTodasTasksPendentes()
        {
            return await _ITodoTaskRepository.ListarTodasTasksPendentes();
        }

        public async Task<bool> Update(ToDoTask Task)
        {
            return await _ITodoTaskRepository.Update(Task);
        }

        public async Task<ToDoTask> GetById(Guid Id)
        {
            return await _ITodoTaskRepository.GetById(Id);
        }

        public async Task<IEnumerable<ToDoTask>> ListarTodasTasksConcluidas()
        {
            return await _ITodoTaskRepository.ListTodasTasksConcluidas();
        }

        public async Task<IEnumerable<ToDoTask>> ListarTodasTasksInativas()
        {
            return await _ITodoTaskRepository.ListTodasTasksInativas();
        }

        public async Task<bool> ConcluirTask(ToDoTask task)
        {
            return await _ITaskTodoService.ConcluirTask(task);
        }

        public async Task<bool> PendenciarTask(ToDoTask task)
        {
            return await _ITaskTodoService.PendenciarTask(task);
        }

        public async Task<bool> ReativarTask(ToDoTask task)
        {
            return await _ITaskTodoService.ReativarTask(task);
        }

        public void Dispose()
        {
            _ITodoTaskRepository?.Dispose();
            _ITaskTodoService?.Dispose();
        }
    }
}

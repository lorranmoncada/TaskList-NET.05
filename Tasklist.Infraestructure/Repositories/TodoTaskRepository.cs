using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasklist.Domain.Enum;
using Tasklist.Domain.Interface;
using Tasklist.Domain.Model;
using Tasklist.Infraestructure.Generic;

namespace Tasklist.Infraestructure.Repositories
{
    public class TodoTaskRepository : RepositoryGeneric<ToDoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository()
        {
        }

        public async Task<IEnumerable<ToDoTask>> ListarTodasTasksPendentes()
        {
            return await _context.ToDoTask.AsNoTracking().Where(task => task.Status.Equals(StatusEnum.Pendente)  && task.Ativo.Equals(true)).ToListAsync();
        }

        public async Task<IEnumerable<ToDoTask>> ListTodasTasksConcluidas()
        {
            return await _context.ToDoTask.AsNoTracking().Where(task => task.Status.Equals(StatusEnum.Concluido) && task.Ativo.Equals(true)).ToListAsync();
        }

        public async Task<IEnumerable<ToDoTask>> ListTodasTasksInativas()
        {
            return await _context.ToDoTask.AsNoTracking().Where(task => task.Ativo.Equals(false)).ToListAsync();
        }
    }
}

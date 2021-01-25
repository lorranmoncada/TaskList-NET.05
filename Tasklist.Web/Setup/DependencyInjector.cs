using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasklist.Application.AppService;
using Tasklist.Domain;
using Tasklist.Domain.Interface;
using Tasklist.Domain.Service;
using Tasklist.Infraestructure;
using Tasklist.Infraestructure.Generic;
using Tasklist.Infraestructure.Repositories;

namespace Tasklist.Web.Setup
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            services.AddScoped<ITodoTaskAppService, ToDoTaskAppService>();
            services.AddScoped<ITaskTodoService, TaskTodoService>();
            services.AddScoped<TaskContext>();
        }
    }
}

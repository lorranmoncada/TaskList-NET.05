using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasklist.Application.AppService;
using Tasklist.Domain.Enum;
using Tasklist.Domain.Model;

namespace Tasklist.Web.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class TaskController : ControllerBase
    {
        private readonly ITodoTaskAppService _ITodoTaskAppService;

        public TaskController(ITodoTaskAppService ITodoTaskAppService)
        {
            _ITodoTaskAppService = ITodoTaskAppService;
        }

        [HttpPost]
        [Route("cadastro/task")]
        public async Task<IActionResult> CadastrarTask([FromBody] ToDoTask task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Objeto Inválido");
                }
                await _ITodoTaskAppService.Add(task);

                return Ok(task.Status == StatusEnum.Pendente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("update/task")]
        public async Task<IActionResult> EditarTask([FromBody] ToDoTask toDoTask)
        {

            try
            {
                var task = await _ITodoTaskAppService.GetById(toDoTask.Id);

                if (task == null) return NotFound();

                if (!ModelState.IsValid) return BadRequest("Objeto Task Inválido");

                task.AdicionarDescricao(toDoTask.Descricao);
                task.AdicionarTitulo(toDoTask.Titulo);
                await _ITodoTaskAppService.Update(task);

                return Ok(await _ITodoTaskAppService.Update(task));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("inativar/task")]
        public async Task<IActionResult> InativarTask([FromBody] ToDoTask toDoTask)
        {

            try
            {
                var task = await _ITodoTaskAppService.GetById(toDoTask.Id);

                if (task == null) return NotFound();     

                return Ok(await _ITodoTaskAppService.InativarTask(task));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("concluir/task")]
        public async Task<IActionResult> ConcluirTask([FromBody] ToDoTask toDoTask)
        {

            try
            {
                var task = await _ITodoTaskAppService.GetById(toDoTask.Id);

                if (task == null) return NotFound();

                await _ITodoTaskAppService.ConcluirTask(task);

                return Ok(Enum.GetName(task.Status));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("pendenciar/task")]
        public async Task<IActionResult> PendenciarTask ([FromBody] ToDoTask toDoTask)
        {

            try
            {
                var task = await _ITodoTaskAppService.GetById(toDoTask.Id);

                if (task == null) return NotFound();

                await _ITodoTaskAppService.PendenciarTask(task);

                return Ok(Enum.GetName(task.Status));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("reativar/task")]
        public async Task<IActionResult> ReativarTask([FromBody] ToDoTask toDoTask)
        {

            try
            {
                var task = await _ITodoTaskAppService.GetById(toDoTask.Id);

                if (task == null) return NotFound();

                return Ok(await _ITodoTaskAppService.ReativarTask(task));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("tasks-pendentes")]
        public async Task<IEnumerable<ToDoTask>> ListarTodasTasksPendentes()
        {
            try
            {
                
                return await _ITodoTaskAppService.ListarTodasTasksPendentes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        [Route("tasks-concluidas")]
        public async Task<IEnumerable<ToDoTask>> ListTodasTasksConcluidas()
        {
            try
            {
                return await _ITodoTaskAppService.ListarTodasTasksConcluidas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("tasks-inativas")]
        public async Task<IEnumerable<ToDoTask>> ListTodasTasksInativas()
        {
            try
            {
                return await _ITodoTaskAppService.ListarTodasTasksInativas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

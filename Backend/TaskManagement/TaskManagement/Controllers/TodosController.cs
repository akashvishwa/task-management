using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : SuperController
    {
        private readonly ITodoService todoService;

        public TodosController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpPost("UpsertTodos")]
        public async Task<IActionResult> UpsertTodos(TodoDto data)
        {
            var res=await todoService.UpsertTodo(data);
            return Ok(res);            
        }

        [HttpGet("GetTodos")]
        public async Task<IActionResult> GetTodos(Guid? UserId,Guid? TodoId)
        {
            var result=await todoService.GetTodos(UserId, TodoId);
            return Ok(result);
        }

        [HttpPost("UpsertTodoComment")]
        public async Task<IActionResult> UpsertTodoComment(TodoCommentDto todoCommentDto)
        {
            var res=await todoService.UpsertCommentAsync(todoCommentDto);
            return Ok(res);
        }

        [HttpGet("GetCommentsByTodoId")]
        public async Task<IActionResult> GetCommentsByTodoId(Guid todoId)
        {
            var res=await todoService.GetTodoComments(todoId);
            return Ok(res);
        }


        [HttpGet("GetTodoStatuses")]
        public async Task<IActionResult> GetTodoStatuses()
        {
            var res=await todoService.GetTodoStatuses();
            return Ok(res);
        }

        [HttpPost("UploadTodoFile")]
        public async Task<IActionResult> UploadTodoFile(IList<TodoFileDto> data)
        {
            var res = await todoService.AddTodoFiles(data);
            return Ok(res);
        }

        [HttpGet("ListTodoFiles")]
        public async Task<IActionResult> ListTodoFiles(Guid TodoId)
        {
            var res= await todoService.ListTodoFiles(TodoId);
            return Ok(res);
        }

        [HttpGet("GetFile")]
        public async Task<IActionResult> GetFileByName(string uniqueName,string Type)
        {
            var res = await todoService.GetFileByName(uniqueName);
            return File(res,Type, uniqueName);
        }

    }
}

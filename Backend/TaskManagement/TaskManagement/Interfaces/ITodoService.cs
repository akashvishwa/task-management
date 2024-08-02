using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.Interfaces
{
    public interface ITodoService
    {
        Task<IList<Todo>> GetTodos(Guid? UserId, Guid? TodoId);
        Task<bool> UpsertTodo(TodoDto tododata);

        Task<bool> UpsertCommentAsync(TodoCommentDto todoComment);
        Task<IList<TodoComment>> GetTodoComments(Guid TodoId);

        Task<IList<TodoStatus>> GetTodoStatuses();

        // for files
        Task<bool> AddTodoFiles(IList<TodoFileDto> data);
        Task<IList<TodoFiles>> ListTodoFiles(Guid TodoId);
        Task<Byte[]> GetFileByName(string uniqueName );

    }
}

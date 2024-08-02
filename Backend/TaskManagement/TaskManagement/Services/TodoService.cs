using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagement.Dto;
using TaskManagement.Infrastructure;
using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class TodoService:ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Todo>> GetTodos(Guid? UserId,Guid? TodoId) 
        {
            var query= _context.Todos.Include(x=>x.TodoStatus);   
            
            if(UserId == null ) 
            { 
                query.Where(x=>x.EmployeeId == UserId);
            }
            if (TodoId == null)
            {
                query.Where(x => x.TodoId == TodoId);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> UpsertTodo(TodoDto tododata) 
        {
            if (tododata == null)
            {
                return false;
            }

            if (tododata.TodoId == null)
            {
                var todo = new Todo() {
                Name= tododata.Name,
                Description= tododata.Description,
                EmployeeId= tododata.EmployeeId,
                Notes= tododata.Notes,
                TodoStatusId= tododata.TodoStatusId,
                EndingDate=tododata.EndingDate
                };
                await _context.Todos.AddAsync(todo);
            }
            else
            {
                var todo =await _context.Todos.FirstOrDefaultAsync(x=>x.TodoId==tododata.TodoId);
                if (todo != null)
                {
                    todo.Name = tododata.Name;
                    todo.Description = tododata.Description;
                    todo.EmployeeId = tododata.EmployeeId;
                    todo.Notes = tododata.Notes;
                    todo.TodoStatusId = tododata.TodoStatusId;
                    todo.EndingDate = tododata.EndingDate;
                    todo.UpdatedOn=DateTime.Now;
                    _context.Todos.Update(todo);
                }
            }
            await  _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpsertCommentAsync(TodoCommentDto todoComment)
        {
            if (todoComment == null)
            {
                return false;
            }

            if (todoComment.Id != null)
            {
                 var comment=await _context.TodosComments.FindAsync(todoComment.Id); 
                if (comment != null)
                {
                    comment.UpdatedOn = DateTime.Now;
                    comment.Comment=todoComment.Comment;
                    comment.TodoId = todoComment.TodoId;
                    _context.Update(comment);
                }
            }
            else
            {
                var comment = new TodoComment()
                {
                    Comment = todoComment.Comment,
                    TodoId = todoComment.TodoId,
                };


            }
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IList<TodoComment>> GetTodoComments(Guid TodoId)
        {
            var result=await _context.TodosComments.Where(x=>x.TodoId == TodoId).ToListAsync();
            return result;
        }

        public async Task<IList<TodoStatus>> GetTodoStatuses()
        {
            var result = await _context.TodoStatuses.ToListAsync();
            return result;
        }

        public async Task<bool> AddTodoFiles(IList<TodoFileDto> data)
        {
            if(data.Count>0)
            {
                foreach (var item in data)
                {
                    var uniqueName = Guid.NewGuid().ToString()+"_"+item.File.FileName;
                    var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "UploadedFiles");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.File.CopyToAsync(fileStream);
                    }
                    var todoFile = new TodoFiles()
                    {
                        TodoId=item.TodoId,
                        Type=item.File.ContentType,
                        Name=item.File.Name,
                        UniqueName=uniqueName,
                    };
                    await _context.TodosFiles.AddAsync(todoFile);
                    await _context.SaveChangesAsync();

                }
                return true;
            }
            else
            {
                return true;
            }
        }

        public async Task<IList<TodoFiles>> ListTodoFiles(Guid TodoId)
        {
            return _context.TodosFiles.Where(x=>x.TodoId==TodoId).ToList();
        }

        public async Task<Byte[]> GetFileByName(string uniqueName)
        {
            string uploads = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "UploadedFiles");
            string filePath = Path.Combine(uploads, uniqueName);
            Byte[] bytes = File.ReadAllBytes(filePath);
            return bytes;
        }
    }
}

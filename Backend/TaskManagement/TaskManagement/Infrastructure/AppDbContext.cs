using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Infrastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context):base( context)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoStatus> TodoStatuses { get; set; }
        public DbSet<TodoComment> TodosComments { get; set;}
        public DbSet<TodoFiles> TodosFiles { get; set;}
    }
}

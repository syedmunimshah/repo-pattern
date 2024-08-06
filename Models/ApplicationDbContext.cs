using Microsoft.EntityFrameworkCore;

namespace Repository.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<TodoItem> tbl_TodoItems { get; set; }

    }
}

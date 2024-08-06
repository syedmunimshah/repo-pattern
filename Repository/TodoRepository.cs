using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repository
{
    public class TodoRepository<T> : ITodoRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
   
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
           

        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.tbl_TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            return await _context.tbl_TodoItems.FindAsync(id);
        }
        public async Task AddAsync(TodoItem item)
        {
             _context.tbl_TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem item)
        {
         
           _context.tbl_TodoItems.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.tbl_TodoItems.FindAsync(id);
            if (item != null)
            {
                _context.tbl_TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

     

     

        
    }    
}

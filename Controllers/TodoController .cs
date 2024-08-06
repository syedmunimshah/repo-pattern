using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repository;

namespace Repository.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository<TodoItem> _repository;
        public TodoController(ITodoRepository<TodoItem> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _repository.GetAllAsync();
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

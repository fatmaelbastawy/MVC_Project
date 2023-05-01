using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stor.Models;

namespace Stor.Controllers
{
    public class TaskCategories : Controller
    {
        private readonly Context _context;

        public TaskCategories(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskCategories.OrderByDescending(x => x.Id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var taskCategories = await _context.TaskCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(taskCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] TaskCategory taskCategories)
        {
            _context.Add(taskCategories);
            await _context.SaveChangesAsync();
            return View(taskCategories);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var taskCategoriess = await _context.TaskCategories.FindAsync(id);
            if (taskCategoriess == null)
            {
                return NotFound();
            }
            return View(taskCategoriess);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,CategoryName")] TaskCategory taskCategories)
        {
            _context.Update(taskCategories);
            await _context.SaveChangesAsync();
            return View(taskCategories);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var taskCategoriess = await _context.TaskCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskCategoriess == null)
            {
                return NotFound();
            }
            return View(taskCategoriess);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskCategories = await _context.TaskCategories.FindAsync(id);
            _context.TaskCategories.Remove(taskCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stor.Models;

namespace Stor.Controllers
{
    public class UsersController : Controller
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.OrderByDescending(x => x.Id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var categorys = await _context.Users.FindAsync(id);
            if (categorys == null)
            {
                return NotFound();
            }
            return View(categorys);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Name,Email")] User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var User = await _context.Users.FindAsync(id);
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
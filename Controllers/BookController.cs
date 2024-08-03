using library_automation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library_automation.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        private readonly dbContext _dbContext;
        public BookController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var books = from b in _dbContext.Books
                        select b;
            return View(await books.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            var details = await _dbContext.Books
            .Include(a => a.Author)
            .FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
    }
}

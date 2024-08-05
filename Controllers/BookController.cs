using library_automation.Data;
using library_automation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_dbContext.Authors, "Id", "FirstName");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorId,Title,Publisher,PublicationYear,Genre")] Book book)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(book);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_dbContext.Authors, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_dbContext.Authors, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuthorId,Title,Publisher,PublicationYear,Genre")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(book);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_dbContext.Authors, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _dbContext.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _dbContext.Books.Any(e => e.Id == id);
        }
    }
}

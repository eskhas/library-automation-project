using library_automation.Data;
using library_automation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace library_automation.Controllers
{
    public class BookController : Controller
    {
        private readonly dbContext _context;
        public BookController(dbContext context)
        {
            _context = context;
        }
        // GET: BookController
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = $"{b.Author.FirstName} {b.Author.LastName}",
                    Publisher = b.Publisher,
                    PublicationYear = b.PublicationYear,
                    Genre = b.Genre
                })
                .ToListAsync();
            return View(books);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var details = await _context.Books
            .Include(a => a.Author)
            .Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Author = $"{b.Author.FirstName} {b.Author.LastName}",
                Publisher = b.Publisher,
                PublicationYear = b.PublicationYear,
                Genre = b.Genre
            })
            .FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
        // GET: Book/Create
        public IActionResult Create()
        {
            var bookAuthorViewModel = new BookAuthorViewModel();

            var authorViewModel = _context.Authors.Select(b => new AuthorViewModel
            {
                Id = b.Id,
                AuthorFullName = $"{b.FirstName} {b.LastName}",
            });
            ViewData["Author"] = new SelectList(authorViewModel, "Id", "AuthorFullName");
            return View(bookAuthorViewModel);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book,Author")] BookAuthorViewModel bookAuthorViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAuthorViewModel.Book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName", bookAuthorViewModel.Book.AuthorId);
            return View(bookAuthorViewModel);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookAuthorViewModel = new BookAuthorViewModel
            {
                Book = book
            };

            var authorViewModel = _context.Authors.Select(b => new AuthorViewModel
            {
                Id = b.Id,
                AuthorFullName = $"{b.FirstName} {b.LastName}",
            });

            ViewData["Author"] = new SelectList(authorViewModel, "Id", "AuthorFullName", book.AuthorId);
            return View(bookAuthorViewModel);
        }


        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Book,Author")] BookAuthorViewModel viewModel)
        {
            if (id != viewModel.Book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(viewModel.Book.Id))
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
            var authorViewModel = _context.Authors.Select(b => new AuthorViewModel
            {
                Id = b.Id,
                AuthorFullName = $"{b.FirstName} {b.LastName}",
            });
            ViewData["Author"] = new SelectList(authorViewModel, "Id", "AuthorFullName", viewModel.Book.AuthorId);
            return View(viewModel);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
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
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}

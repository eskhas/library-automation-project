using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using library_automation.Models;
using library_automation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace library_automation.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext _context;
        public HomeController(dbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                                      .Include(b => b.Author) // Assuming you have a relationship between Book and Author
                                      .ToListAsync();

            var bookAvailability = books.Select(book => new BookAvailabilityViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Publisher = book.Publisher != null ? book.Publisher : "Unknown Publisher",
                IsAvailable = !_context.Loans.Any(loan => loan.BookId == book.Id && !loan.IsReturned)
            }).ToList();

            return View(bookAvailability);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var details = await _context.Books
            .Include(a => a.Author)
            .FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
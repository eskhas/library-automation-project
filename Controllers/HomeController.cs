using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using library_automation.Models;
using library_automation.Data;
using Microsoft.EntityFrameworkCore;

namespace library_automation.Controllers;

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
        var books = from b in _context.Books
                    select b;
        return View(await books.ToListAsync());
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

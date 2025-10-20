using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aznews.Models;
using aznew.Models;

namespace aznews.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _context;

    public HomeController(ILogger<HomeController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("/Post-{slug}-{id:long}.html", Name = "Details")]
    public IActionResult Details(long? id)
    {
        if (id == null) return NotFound();
        var post = _context.viewPostMenus
            .FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
        if (post == null) return NotFound();
        return View(post);
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcapp.Models;

namespace mvcapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApiDbContext context;

    public HomeController(ILogger<HomeController> logger, ApiDbContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public IActionResult Index()
    {
        var blogs = context.Blogs.ToList();
        return View(blogs);
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

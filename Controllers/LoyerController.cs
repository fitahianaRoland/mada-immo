using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace mada_immo.Controllers;

public class    LoyerController : Controller
{
    private readonly ILogger<   LoyerController> _logger;

    public  LoyerController(ILogger<  LoyerController> logger)
    {
        _logger = logger;
    }

    public IActionResult ListeLoyer()
    {
        return View();
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

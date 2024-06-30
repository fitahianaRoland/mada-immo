using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace mada_immo.Controllers;

public class ChiffreAffaireController : Controller
{
    private readonly ILogger<ChiffreAffaireController> _logger;

    public ChiffreAffaireController(ILogger<ChiffreAffaireController> logger)
    {
        _logger = logger;
    }

    public IActionResult ChiffreAffaire()
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

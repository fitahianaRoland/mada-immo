using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace mada_immo.Controllers;

public class BienController : Controller
{
    private readonly ILogger<BienController> _logger;
    private readonly BienRepository _bienRepository;

    public BienController(ILogger<BienController> logger, BienRepository bienRepository)
    {
        _logger = logger;
        _bienRepository = bienRepository;
    }

    public IActionResult ListeBien()
    {
        List<Bien> ListeBien = _bienRepository.FindAll();
        ViewBag.listeBien = ListeBien;
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

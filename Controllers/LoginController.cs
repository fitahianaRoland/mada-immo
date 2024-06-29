using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace mada_immo.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly AdminRepository _adminRepository;

    public LoginController(
        ILogger<LoginController> logger,
        AdminRepository adminRepository
    )
    {
        _logger = logger;
        _adminRepository = adminRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LoginPageAdmin()
    {
        ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
        return View();
    }

    public IActionResult VerificationLoginAdmin(string email, string password)
    {
        try
        {
            string id = _adminRepository.VerificationLoginAdmin(email, password);
            Console.WriteLine("verification succes");

            HttpContext.Session.SetString("id_admin", id);
            return Redirect("../Etape/InterfaceEquipPage");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("verification faild");
            TempData["ErrorMessage"] = ex.Message;
            return Redirect("LoginPageAdmin");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

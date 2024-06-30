using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace mada_immo.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly AdminRepository _adminRepository;
    private readonly ProprietaireRepository _proprietaireRepository;

    private readonly ClientRepository _clientRepository;

    public LoginController(
        ILogger<LoginController> logger,
        AdminRepository adminRepository,
        ProprietaireRepository proprietaireRepository,
        ClientRepository clientRepository
    )
    {
        _logger = logger;
        _adminRepository = adminRepository;
        _proprietaireRepository = proprietaireRepository;
        _clientRepository = clientRepository;
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

    public IActionResult LoginPageProprietaire()
    {
        ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
        return View();
    }

    public IActionResult LoginPageClient()
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
            return Redirect("../Chiffre/ChiffreAffaire");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("verification faild");
            TempData["ErrorMessage"] = ex.Message;
            return Redirect("LoginPageAdmin");
        }
    }

    public IActionResult VerificationLoginProprietaire(string numero)
    {
        try
        {
            string id = _proprietaireRepository.VerificationLoginProprietaire(numero);
            Console.WriteLine("verification succes");

            HttpContext.Session.SetString("id_proprietaire", id);
            return Redirect("../Bien/ListeBien");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("verification faild");
            TempData["ErrorMessage"] = ex.Message;
            return Redirect("LoginPageProprietaire");
        }
    }

    public IActionResult VerificationLoginClient(string email)
    {
        try
        {
            string id = _clientRepository.VerificationLoginClient(email);
            Console.WriteLine("verification succes");

            HttpContext.Session.SetString("id_client", id);
            return Redirect("../Loyer/ListeLoyer");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("verification faild");
            TempData["ErrorMessage"] = ex.Message;
            return Redirect("LoginPageProprietaire");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

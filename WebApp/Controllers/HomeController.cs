using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entities.Models;
using WebApp.Entities.ViewModels.Home;
using WebApp.Services.InterFace;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomeServices _homeServices;

    public HomeController(ILogger<HomeController> logger, IHomeServices homeServices)
    {
        _logger = logger;
        _homeServices = homeServices;
    }

    [Route("/")]
    [Route("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [Route("/loginview")]
    public IActionResult LoginView()
    {
        return PartialView("_LoginForm");
    }

    [Route("/")]
    [Route("/login")]
    [HttpPost]
    public IActionResult Login([FromForm] LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            string message = _homeServices.Login(loginViewModel);
            if (message == "All Perfect")
            {
                return Json(new { redirectUrl = "/home" });
            }
            ModelState.AddModelError("customerErrorMessage", message);
            return PartialView("_LoginForm", loginViewModel);
        }
        return PartialView("_LoginForm", loginViewModel);
    }

    [Route("/logout")]
    [Authorize(Roles = "Admin,User")]
    public IActionResult Logout()
    {
        return Redirect("/");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

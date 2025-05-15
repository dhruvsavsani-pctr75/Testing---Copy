using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class UserController : Controller
{
    public UserController()
    {

    }
    
    [Route("/home")]
    [Authorize]
    public IActionResult Home()
    {
        return View();
    }
}

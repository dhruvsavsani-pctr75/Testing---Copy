using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities.Models;
using WebApp.Entities.ViewModels.Home;
using WebApp.Repositories.Interface;
using WebApp.Services.InterFace;
using WebApp.Services.InterFace.Extra;

namespace WebApp.Services.Implementation;

public class HomeServices : IHomeServices
{
    private readonly IUserRepository _userRepository;
    private readonly IAddFunctionality _addFunctionality;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public HomeServices(IUserRepository userRepository, IAddFunctionality addFunctionality, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _addFunctionality = addFunctionality;
        _httpContextAccessor = httpContextAccessor;
    }
    public string Login(LoginViewModel loginViewModel)
    {
        User user = _userRepository.GetQueryable().Include(u => u.Role).Where(u => !u.Isdeleted && u.Username == loginViewModel.UserName).FirstOrDefault();

        if (user == null)
        {
            return "Username doesn't match.";
        }

        if (!_addFunctionality.CompareHash(loginViewModel.Password, user.Password))
        {
            return "Password doesn't match.";
        }

        string JWTToken = _addFunctionality.GenerateJWTTokenRole(user.Role.Role1, loginViewModel.UserName, user.Id);
        _httpContextAccessor.HttpContext?.Response.Cookies.Append("Authorization", JWTToken, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddHours(5),
            HttpOnly = true, // Accessible only by the server
            IsEssential = true // Required for GDPR compliance
        });

        return "All Perfect";
    }

    public bool Logout()
    {
        HttpContext? httpContext = _httpContextAccessor.HttpContext;
        httpContext?.Response.Cookies.Delete("Authorization");
        return true;
    }
}

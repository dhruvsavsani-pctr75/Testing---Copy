using WebApp.Entities.ViewModels.Home;

namespace WebApp.Services.InterFace;

public interface IHomeServices
{
    string Login(LoginViewModel loginViewModel);
    bool Logout();
}

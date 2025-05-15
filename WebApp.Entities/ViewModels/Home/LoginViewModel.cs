using System.ComponentModel.DataAnnotations;

namespace WebApp.Entities.ViewModels.Home;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username is required field.")]
    public string UserName { get; set; } = "";

    [Required(ErrorMessage = "Password is required field.")]
    [MinLength(8, ErrorMessage = "Minimum password length is 8")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, contain one uppercase letter, one number, and one special character.")]
    public string Password { get; set; } = "";
}

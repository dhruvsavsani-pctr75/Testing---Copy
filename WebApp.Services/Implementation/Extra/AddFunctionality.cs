using Microsoft.Extensions.Configuration;
namespace WebApp.Services.Implementation.Extra;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using WebApp.Services.InterFace.Extra;

public class AddFunctionality : IAddFunctionality
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IWebHostEnvironment _webHostEnvironment;

    public AddFunctionality(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _webHostEnvironment = webHostEnvironment;
    }

    public string GenerateJWTTokenRole(string userRole, string userName, int userId)
    {
        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.Role, userRole),
            new (ClaimTypes.Name, userName),
            new (ClaimTypes.NameIdentifier, userId.ToString()),
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "6jdf5GJ0xI5cmzq4z8sZl18lmj6qfsk="));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(30),  // Token expiration time (e.g., 1 hour)
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);  // Return the token as a string
    }

    public string MakeHash(string value)
    {
        return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(value)));
    }

    public bool CompareHash(string plainString, string hashString)
    {
        if (MakeHash(plainString) == hashString)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int getLogedInUserId()
    {
        string? userIdSrting = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (int.TryParse(userIdSrting, out int userId))
        {
            return userId;
        }
        return 1;
    }

    public string UploadResume(IFormFile file)
    {
        if (file != null)
        {
            string uploadDirecotroy = @"uploads\";
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, uploadDirecotroy);
            uploadPath = uploadPath.Replace("\\", "/");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadPath, fileName);

            using (FileStream strem = File.Create(filePath))
            {
                file.CopyTo(strem);
            }
            return fileName;
        }
        return "";
    }

}

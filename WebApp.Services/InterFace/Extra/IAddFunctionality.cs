using Microsoft.AspNetCore.Http;

namespace WebApp.Services.InterFace.Extra;

public interface IAddFunctionality
{
    public string MakeHash(string value);
    public bool CompareHash(string plainString, string hashString);
    public string GenerateJWTTokenRole(string userRole, string userName, int userId);
    public int getLogedInUserId();
    string UploadResume(IFormFile file);
}

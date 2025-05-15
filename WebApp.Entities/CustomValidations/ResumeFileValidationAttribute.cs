using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace pizzashop.Entity.CustomValidations;

public class ResumeFileValidationAttribute : ValidationAttribute
{
    private readonly string[] _validExtensions = { ".pdf" };
    private readonly string[] _validMimeTypes = { "application/pdf"};

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        IFormFile? file = value as IFormFile;

        if (file == null)
        {
            return ValidationResult.Success;  // If no file is uploaded, it's not an error (You can adjust this as needed)
        }

        // Check file extension
        string fileExtension = Path.GetExtension(file.FileName).ToLower();
        if (Array.Exists(_validExtensions, ext => ext.Equals(fileExtension)))
        {
            return ValidationResult.Success;  // Valid image extension
        }

        // Check MIME type
        if (Array.Exists(_validMimeTypes, mime => mime.Equals(file.ContentType)))
        {
            return ValidationResult.Success;  // Valid image MIME type
        }

        return new ValidationResult("The file must be an image of type pdf.");
    }
}
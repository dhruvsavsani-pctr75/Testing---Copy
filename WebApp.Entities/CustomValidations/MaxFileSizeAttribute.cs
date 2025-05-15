using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace pizzashop.Entity.CustomValidations;

public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly long _maxSizeInBytes;
    public MaxFileSizeAttribute(long maxSizeInBytes)
    {
        _maxSizeInBytes = maxSizeInBytes;
    }
    public override bool IsValid(object value)
    {
        IFormFile? file = value as IFormFile;
        if (file == null)
        {
            return true;
        }
        else if (file.Length > _maxSizeInBytes)
        {
            return false;
        }
        return true;
    }
    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage(_maxSizeInBytes.ToString());
    }
}

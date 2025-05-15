using System.ComponentModel.DataAnnotations;

namespace pizzashop.Entity.CustomValidations;

public class ValidSelectionAttribute : ValidationAttribute
{
    private readonly string _defaultValue;

    public ValidSelectionAttribute(string defaultValue)
    {
        _defaultValue = defaultValue;
    }

    public override bool IsValid(object value)
    {
        // Check if the value is equal to the default value, if so, return false.
        return value != null && !value.ToString().Equals(_defaultValue, StringComparison.OrdinalIgnoreCase);
    }
}

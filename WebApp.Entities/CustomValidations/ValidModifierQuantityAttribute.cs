using System.ComponentModel.DataAnnotations;

namespace pizzashop.Entity.CustomValidations;

public class ValidModifierQuantityAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
            return false;

        // Try to parse the value to an integer
        if (int.TryParse(value.ToString(), out int result))
        {
            // Ensure the value is at least 1
            return result >= 0;
        }

        // If it's not a valid number, return false
        return false;
    }
}

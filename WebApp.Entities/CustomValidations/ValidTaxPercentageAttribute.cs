using System.ComponentModel.DataAnnotations;

namespace pizzashop.Entity.CustomValidations;

public class ValidTaxPercentageAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
            return false;

        // Try to parse the string value to a decimal
        if (decimal.TryParse(value.ToString(), out decimal result))
        {
            // Check if the decimal value is between 0 and 100
            if (result >= 0 && result <= 100)
                return true;
        }

        // If it's not a valid decimal or out of range, return false
        return false;
    }
}

namespace pizzashop.Entity.CustomValidations;

using System.ComponentModel.DataAnnotations;

public class NoOfPersonRangeAttribute : ValidationAttribute
{
    public NoOfPersonRangeAttribute() : base("No of person must be between 1 and 100.")
    {
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string stringValue)
        {
            // Try parsing the string value to an integer
            if (int.TryParse(stringValue, out int number))
            {
                if (number >= 1 && number <= 100)
                {
                    return ValidationResult.Success; // Valid if within range
                }
            }
        }
        return new ValidationResult("No of person must be between 1 and 100."); // Invalid if not in range
    }
}


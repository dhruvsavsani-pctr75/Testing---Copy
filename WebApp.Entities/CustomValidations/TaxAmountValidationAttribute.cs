using System.ComponentModel.DataAnnotations;

namespace pizzashop.Entity.CustomValidations;

public class TaxAmountValidationAttribute : ValidationAttribute
{
    public string TaxTypeProperty { get; set; }

    public TaxAmountValidationAttribute(string taxTypeProperty)
    {
        TaxTypeProperty = taxTypeProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string? taxType = validationContext.ObjectType.GetProperty(TaxTypeProperty)?.GetValue(validationContext.ObjectInstance, null) as string;

        if (taxType == null)
        {
            return new ValidationResult("TaxType is not specified");
        }

        string? taxAmount = value as string;
        if (string.IsNullOrEmpty(taxAmount))
        {
            return new ValidationResult("Tax Amount is required");
        }

        if (taxType == "Percentage")
        {
            if (double.TryParse(taxAmount, out double percentageAmount))
            {
                if (percentageAmount < 0 || percentageAmount > 100)
                {
                    return new ValidationResult("Tax Amount must be between 0 and 100 for Percentage type");
                }
            }
            else
            {
                return new ValidationResult("Tax Amount must be a valid number for Percentage type");
            }
        }
        else if (taxType == "Flat Amount")
        {
            if (double.TryParse(taxAmount, out double flatAmount))
            {
                if (flatAmount < 0)
                {
                    return new ValidationResult("Tax Amount must be a non-negative value for Flat Amount type");
                }
            }
            else
            {
                return new ValidationResult("Tax Amount must be a valid number for Flat Amount type");
            }
        }

        return ValidationResult.Success;
    }
}

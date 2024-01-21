using System.ComponentModel.DataAnnotations;

namespace CrudStudent.Models
{
    public class SalaryRange :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                double? Salary = (double)value;
                    if (Salary >= 12000 && Salary <= 60000 )
                    {
                        return ValidationResult.Success;
                    }
                
            }

            return new ValidationResult(ErrorMessage ?? "Salary should between 12k and 60k");
        }
    }
}

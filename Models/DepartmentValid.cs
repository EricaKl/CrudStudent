using System.ComponentModel.DataAnnotations;

namespace CrudStudent.Models
{
    public class DepartmentValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string? Dept = (string)value;
                if (Dept.ToUpper() == "IT" || Dept.ToUpper() == "HR" || Dept.ToUpper() == "ACCTS")
                {
                    return ValidationResult.Success;
                }

            }

            return new ValidationResult(ErrorMessage ?? "Dept should be HR, Accts and IT");
        }
    }
}

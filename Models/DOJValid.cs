using System.ComponentModel.DataAnnotations;

namespace CrudStudent.Models
{
    public class DOJValid: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? DateOfJoining = (DateTime)value;
                if (DateOfJoining != null)
                {
                    
                    if (DateOfJoining <= DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult(ErrorMessage ?? "Date Of Joining should be less than equal to current date");
        }
    }
}
        

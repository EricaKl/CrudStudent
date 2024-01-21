using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CrudStudent.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "EmpId is Required")]
        [Remote("IsIdAvailable", "Employee", HttpMethod = "POST", 
            ErrorMessage = "Employee Id already exists.")]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression("[A-Z a-z]+", ErrorMessage ="Only Alphabets allowed")]
        [MinLength(10,ErrorMessage ="Min 10 characters Needed")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "DOJ is Required")]
        [DOJValid]
        public DateTime DateOfJoining { get; set; }
        [SalaryRange]
        public double ? Salary { get; set; }
        [DepartmentValid]
        [Required(ErrorMessage = "Department is Required")]
        public string Department {  get; set; }
        [Required(ErrorMessage="DOB is Required")]
        [DOBValid]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords does not match")]
        public string ReTypePassword { get; set; } 
    }
}

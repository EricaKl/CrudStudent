using CrudStudent.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudStudent.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){Id = 1, Name ="Deepak", Batch = "B009", Marks = 78},
                new Student(){Id = 2, Name = "Mahi" , Batch="B001", Marks = 67}
            };
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }
}

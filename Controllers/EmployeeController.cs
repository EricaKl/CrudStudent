using CrudStudent.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;

namespace CrudStudent.Controllers
{
    public class EmployeeController : Controller
    {

        static List<Employee> list = null;
        public EmployeeController()
        {
            if (list == null)
            {
                list = new List<Employee>()
                {
                 new Employee()
                {
                    EmpId = 1, DateOfJoining = new DateTime(1990,09,23), Department = "IT"
                    , EmpName = "Erica" , Salary = 78000
                },
                 new Employee()
                {
                    EmpId = 2, DateOfJoining = new DateTime(1990,01,22), Department = "IT"
                    , EmpName = "Anshit" , Salary = 344402
                }
                };
            }  
        }
        [HttpPost]
        public JsonResult IsIdAvailable(Employee emp)
        {
           
            return Json(!list.Any(x => x.EmpId == emp.EmpId));
        }
        public IActionResult Display()
        {
           
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
           
            if(ModelState.IsValid)
            {
                list.Add(emp);
                return RedirectToAction("Display");

            }
            else
            {
                return View();
            }
            //}
            
        }

        public IActionResult DisplayById(int? id)
        {
            if(!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID";
                return View();
            }
            else
            {
                var emplistbyid = list.Where(x => x.EmpId == id).FirstOrDefault();
                if (emplistbyid == null)
                {
                    ViewBag.Message = "There is no record exists";
                    return View();
                }
                else
                    return View(emplistbyid);
            }
           
        }

        
        public IActionResult Delete(Employee emp , int? id)
        {
            if(!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID";
                return View();
            }
            else
            {
                var Deleteemp = list.Where(x => x.EmpId == id).FirstOrDefault();
                if (Deleteemp == null)
                {
                    ViewBag.Message = "There is no such record";
                    return View();
                }
                else
                {
                    list.Remove(Deleteemp);
                    return RedirectToAction("Display");
                }
            }
           
        }

        public IActionResult Edit(int? id)
        {
            if(!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; 
                return View();
            }
            else
            {
                var employeedetails = list.Where(x => x.EmpId == id).FirstOrDefault();
                if (employeedetails == null)
                {

                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                return View(employeedetails);

            }
           
            
        }

        [HttpPost]
        public IActionResult Edit(Employee emp, int id) 
        {
            var tempedit = list.Where(x => x.EmpId == id).FirstOrDefault();
            if (tempedit!=null)
            {
                foreach (Employee empobj in list)
                {
                    if (empobj.EmpId == tempedit.EmpId)
                    {
                        empobj.EmpId = emp.EmpId;
                        empobj.EmpName = emp.EmpName;
                        empobj.DateOfJoining = emp.DateOfJoining;
                        empobj.Department = emp.Department;
                        empobj.Salary = emp.Salary;
                        break;
                    }
                }
            }
           
            return RedirectToAction("Display");
        }
        


    }
}

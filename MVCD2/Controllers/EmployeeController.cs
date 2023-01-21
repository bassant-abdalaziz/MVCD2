using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCD2.Models;

namespace MVCD2.Controllers
{
    public class EmployeeController : Controller
    {
        private MVCITIDbContext dbContext;
        public EmployeeController()
        {
            dbContext = new MVCITIDbContext();
        }
        public IActionResult Index()
        {
            List <Employee> employees = dbContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult GetBySSN(int id)
        {
            Employee? employee = dbContext.Employees.Include(s => s.SuperVisor).Where(e => e.SSN == id).SingleOrDefault();
            if (employee == null)
            {
                return View("Error"); 
            }
            return View(employee);  
        }


        public IActionResult Add()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult AddEmployeeDb(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            List<Employee> employees = dbContext.Employees.ToList();
            return View("Index", employees);
        }


        public IActionResult Edit(int id)
        {
            Employee? employee = dbContext.Employees.SingleOrDefault(e => e.SSN == id);
            List<Employee> employees = dbContext.Employees.ToList();
            ViewBag.emp = employees;
            return View(employee);
        }

        public IActionResult EditEmployeeDb(Employee employee)
        {
            Employee? oldEmployee = dbContext.Employees.SingleOrDefault(e => e.SSN == employee.SSN);
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.MiddleName = employee.MiddleName;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.Address = employee.Address;
            oldEmployee.Sex = employee.Sex;
            oldEmployee.BirthDate = employee.BirthDate;
            oldEmployee.Salary = employee.Salary;
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Employee? employee = dbContext.Employees.SingleOrDefault(e => e.SSN == id);
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

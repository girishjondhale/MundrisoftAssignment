using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MundrisoftAssignment.Models;
using MundrisoftAssignment.Services;

namespace MundrisoftAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_employeeService.GetEmployeeById(id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(newEmployee);
                return RedirectToAction("Index");
            }
            return View(newEmployee);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee editedEmployee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(editedEmployee);
                return RedirectToAction("Index");
            }
            return View(editedEmployee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _employeeService.DeleteEmployee(id);
                    if (res == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MundrisoftAssignment.Models;
using MundrisoftAssignment.Services;

namespace MundrisoftAssignment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var department = _departmentService.GetAllDepartments();
            return View(department);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_departmentService.GetDepartmentById(id));
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.AddDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _departmentService.DeleteDepartment(id);
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

using DepartmentApp.Models;
using DepartmentApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DepartmentApp.Controllers
{
    public class DepartmentsController : Controller
    {

        private readonly IDepartmentRepository _dRepo;

        public DepartmentsController(IDepartmentRepository dRepo)
        {
            _dRepo = dRepo;
        }

        public IActionResult Index()
        {
            List<Department> departments = _dRepo.GetDepartments().ToList();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department obj)
        {
            if (ModelState.IsValid)
            {
                _dRepo.CreateDepartment(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Update(int? id)
        {
            Department department = new Department();

            if (id == null || id == 0)
            {
                return NotFound();
            }

            department = _dRepo.GetDepartment(id.GetValueOrDefault());

            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Department obj)
        {
            if (ModelState.IsValid)
            {
                _dRepo.UpdateDepartment(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Department department = _dRepo.GetDepartment(id.GetValueOrDefault());

            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department obj)
        {
            var objExists = _dRepo.DepartmentExists(obj.Id);
            if (objExists == false)
            {
                return NotFound();
            }
            var objDelete = _dRepo.GetDepartment(obj.Id);
            _dRepo.DeleteDepartment(objDelete);
            return RedirectToAction("Index");
        }
    }
}

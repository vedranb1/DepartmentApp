using AutoMapper;
using DepartmentApp.Models;
using DepartmentApp.Models.ViewModels;
using DepartmentApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DepartmentApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonsRepository _pRepo;
        private readonly IDepartmentRepository _dRepo;

        public PersonsController(IPersonsRepository pRepo, IDepartmentRepository dRepo)
        {
            _pRepo = pRepo;
            _dRepo = dRepo;
        }

        public IActionResult Index()
        {
            List<Person> persons = _pRepo.GetPersons().ToList();
            return View(persons);
        }

        public IActionResult Create()
        {
            PersonViewModel createPersonVM = new PersonViewModel()
            {
                Person = new Person(),
                DepartmentDropDown = _dRepo.GetDepartments().Select(dep => new SelectListItem
                {
                    Text = dep.Name,
                    Value = dep.Id.ToString()
                })
            };
            return View(createPersonVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _pRepo.CreatePerson(obj.Person);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Update(int? id)
        {
            PersonViewModel createPersonVM = new PersonViewModel()
            {
                Person = _pRepo.GetPerson(id.GetValueOrDefault()),
                DepartmentDropDown = _dRepo.GetDepartments().Select(person => new SelectListItem
                {
                    Text = person.Name,
                    Value = person.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Person person = _pRepo.GetPerson(id.GetValueOrDefault());

            if (person == null)
            {
                return NotFound();
            }
            return View(createPersonVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PersonViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _pRepo.UpdatePerson(obj.Person);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            PersonViewModel createPersonVM = new PersonViewModel()
            {
                Person = _pRepo.GetPerson(id.GetValueOrDefault()),
                DepartmentDropDown = _dRepo.GetDepartments().Select(person => new SelectListItem
                {
                    Text = person.Name,
                    Value = person.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Person person = _pRepo.GetPerson(id.GetValueOrDefault());

            if (person == null)
            {
                return NotFound();
            }
            return View(createPersonVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PersonViewModel obj)
        {
            var objExists = _pRepo.PersonExists(obj.Person.Id);
            if (objExists == false)
            {
                return NotFound();
            }
            var objDelete = _pRepo.GetPerson(obj.Person.Id);
            _pRepo.DeletePerson(objDelete);
            return RedirectToAction("Index");
        }
    }
}


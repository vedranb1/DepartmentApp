using DepartmentApp.Data;
using DepartmentApp.Models;
using DepartmentApp.Models.ViewModels;
using DepartmentApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DepartmentApp.Repository
{
    public class PersonsRepository : IPersonsRepository
    {

        private readonly ApplicationDbContext _db;

        public PersonsRepository(ApplicationDbContext db)
        {

            _db = db;

        }

        public bool CreatePerson(Person person)
        {
            _db.Persons.Add(person);
            return Save();
        }

        public bool DeletePerson(Person person)
        {
            _db.Persons.Remove(person);
            return Save();
        }

        public Person GetPerson(int personId)
        {
            return _db.Persons.Where(a => a.Id == personId).Include(a => a.Department).FirstOrDefault(); 
        }

        public ICollection<Person> GetPersons()
        {
            return _db.Persons.Include(a => a.Department).OrderBy(a => a.LastName).ToList();
        }

        public bool PersonExists(string name)
        {
            bool value = _db.Persons.Any(a => a.FirstName.ToLower().Trim() == name.ToLower().Trim()
                || a.LastName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool PersonExists(int id)
        {
            return _db.Persons.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdatePerson(Person person)
        {
            _db.Persons.Update(person);
            return Save();
        }
    }

}


using DepartmentApp.Models;
using DepartmentApp.Models.ViewModels;
using System.Collections.Generic;

namespace DepartmentApp.Repository.IRepository
{
    public interface IPersonsRepository
    {

        ICollection<Person> GetPersons();
        Person GetPerson(int personId);
        bool PersonExists(string name);
        bool PersonExists(int id);
        bool CreatePerson(Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(Person person);
        bool Save();

    }
}

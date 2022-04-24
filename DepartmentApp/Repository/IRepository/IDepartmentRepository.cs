using DepartmentApp.Models;
using System.Collections.Generic;

namespace DepartmentApp.Repository.IRepository
{
    public interface IDepartmentRepository
    {

        ICollection<Department> GetDepartments();
        Department GetDepartment(int departmentId);
        bool DepartmentExists(string name);
        bool DepartmentExists(int id);
        bool CreateDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(Department department);
        bool Save();

    }
}

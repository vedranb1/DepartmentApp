using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DepartmentApp.Models.ViewModels
{
    public class PersonViewModel
    {

        public Person Person { get; set; } = new Person();
        public IEnumerable<SelectListItem> DepartmentDropDown { get; set; } = new List<SelectListItem>();

    }
}

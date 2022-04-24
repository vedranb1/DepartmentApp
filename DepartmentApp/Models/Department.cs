using System.ComponentModel.DataAnnotations;

namespace DepartmentApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

    }
}

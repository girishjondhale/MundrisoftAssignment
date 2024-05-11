using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MundrisoftAssignment.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }
        
        [Required(ErrorMessage ="Name Is Required")]
        public string? EmployeeName { get; set; }
        
        [Required(ErrorMessage = "Email Is Required")]

        public string? Email { get; set; }
       
        [Required(ErrorMessage = "City Is Required")]
        public string? City { get; set; }

        public int DepartmentId { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MundrisoftAssignment.Models
{
    [Table("Department")]
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "DepartmentName Is Required")]

        public string? DepartmentName { get; set; }
    }
}

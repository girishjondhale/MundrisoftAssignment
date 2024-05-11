using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MundrisoftAssignment.Models
{
    public enum Role { Admin = 2, Customer };
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName Is Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required")]

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        public int RoleId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ReDoPeAPI.Models
{
    public class UserModel
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}

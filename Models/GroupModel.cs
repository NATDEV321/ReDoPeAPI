using System.ComponentModel.DataAnnotations;

namespace ReDoPeAPI.Models
{
    public class GroupModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<UserModel> Users { get; set; } = new List<UserModel>();
    }
}

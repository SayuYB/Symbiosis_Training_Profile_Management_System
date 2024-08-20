using System.ComponentModel.DataAnnotations;

namespace PlacementDemo.Models
{
    public class RoleKeyword
    {
        [Key]
        public int RoleKeyId { get; set; }
        public string RoleName { get; set; }
        public int KeyId { get; set; }
        public Keyword Keyword { get; set; }
        public int Weight { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PlacementDemo.Models
{
    public class Keyword
    {
        [Key]
        public int KeyId { get; set; }
        public string KeywordName { get; set; }
        public string Category { get; set; }
    }
}

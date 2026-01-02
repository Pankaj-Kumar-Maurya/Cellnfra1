using System.ComponentModel.DataAnnotations;

namespace Cellnfra1.Models
{
    public class tbl_PostContent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Slug { get; set; }
        [Required]
        public string DivSlug { get; set; }
        [Required]
        public string Content { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

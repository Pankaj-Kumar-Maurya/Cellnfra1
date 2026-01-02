using System.ComponentModel.DataAnnotations;

namespace Cellnfra1.Models
{
    public class tbl_Account
    {
        [Key]
        public int AccountID { get; set; }
        public string Email { get; set; }=string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }


    }
}

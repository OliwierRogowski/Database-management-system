using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_management_system.Server.Models
{
    public class LoginDetails
    {
        [Key]
        public int UserId { get; set; } = 0;

        [Column(TypeName ="nvarchar(100)")]
        public string LoginName { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; } = false;
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; } = "";
    }
}

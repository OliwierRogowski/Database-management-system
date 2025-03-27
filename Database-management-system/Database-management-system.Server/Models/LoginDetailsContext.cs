using Microsoft.EntityFrameworkCore;

namespace Database_management_system.Server.Models
{
    public class LoginDetailsContext : DbContext
    {

        // Konstruktor
        public LoginDetailsContext(DbContextOptions options) : base(options)
        {
        }
        // Database model dla LoginDetails.cs
        public DbSet<LoginDetails> LoginDetails { get; set; }
    }
}

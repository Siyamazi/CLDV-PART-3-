using CLDV_Part2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CLDV_Part2.Data
{
    public class ApplicationDb : IdentityDbContext
    {
        public ApplicationDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<James> james{ get; set; }
       

        public DbSet<ApplicationUsercs> ApplicationUsers { get; set; }

        public DbSet<Products> Products { get; set; }

    }

}

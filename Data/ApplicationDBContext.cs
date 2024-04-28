using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieMania.Models;
using System.Data;

namespace MovieMania.Data
{
    // base allows us to pass dbContext into DbContext
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {


        }

        // DbSet return the data from database
        // Defered Execution
        // Manipulating the whole table
        // Linking up the database to the actual code
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Comment> Comment { get; set; }


        // 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },

                   new IdentityRole
                   {
                       Name = "User",
                       NormalizedName = "USER"
                   },
            };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }

}



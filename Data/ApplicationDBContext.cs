using Microsoft.EntityFrameworkCore;
using MovieMania.Models;

namespace MovieMania.Data
{
    // base allows us to pass dbContext into DbContext
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

            
        }

        // DbSet return the data from database
        // Defered Execution
        // Manipulating the whole table
        // Linking up the database to the actual code
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Comment> Comment { get; set; }


    }
}

using System.Data.Entity;

namespace Vidly.Models
{
    public class VidlyContext : DbContext
    {
        public VidlyContext()
        {
        }
        //Entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
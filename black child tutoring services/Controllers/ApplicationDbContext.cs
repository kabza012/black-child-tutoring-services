using black_child_tutoring_services.Models;
using Microsoft.EntityFrameworkCore;

namespace black_child_tutoring_services.Controllers
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Donation> donations { get; set; }
    }
}

using cocktail_project.Models;
using Microsoft.EntityFrameworkCore;

namespace cocktail_project.Contexts
{
    public class TableContexts : DbContext
    {
        public DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Database = AppointmentBooking; " +
                                        "Trusted_Connection = True; TrustServerCertificate = True;");
        }
    }
}


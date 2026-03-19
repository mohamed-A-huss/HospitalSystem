using HospitalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-90JQGSU\\SQLEXPRESS;Database=HospitalSystem;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

using MedicalScan.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalScan.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<DoctorSpeciality> DoctorSpecialties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpeciality>()
                .HasKey(ds => new { ds.DoctorId, ds.SpecialityId });

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecialities)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(ds => ds.Speciality)
                .WithMany(d => d.DoctorSpecialities)
                .HasForeignKey(ds => ds.SpecialityId);
        }


    }
}

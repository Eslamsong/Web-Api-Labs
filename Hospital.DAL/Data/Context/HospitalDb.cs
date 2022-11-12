using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class HospitalDb:DbContext
    {

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Issue>Issues { get; set; } = null!;
        public HospitalDb(DbContextOptions<HospitalDb>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seeding Issues 
            modelBuilder.Entity<Issue>().HasData(
                new Issue { Id=Guid.NewGuid(), Name="Cold"},
                new Issue { Id=Guid.NewGuid(), Name="Stress"},
                new Issue { Id=Guid.NewGuid(), Name="Headache"}
                
                );
            #endregion
            #region Seeding Patients
            
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = Guid.NewGuid(), Name = "Shawn" },
                new Patient { Id = Guid.NewGuid(), Name = "Michal" },
                new Patient { Id = Guid.NewGuid(), Name = "Arnold" }

                );
            #endregion

            #region Seeding Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    Name="Ahmed",
                    Salary=30000,
                    PerformanceRate=90,
                    Specialization="Cardiology"
                },
                 new Doctor
                 {
                     Id = Guid.NewGuid(),
                     Name = "Nancy",
                     Salary = 40000,
                     PerformanceRate = 80,
                     Specialization = "Dermatology"
                 },
                  new Doctor
                  {
                      Id = Guid.NewGuid(),
                      Name = "Wael",
                      Salary = 90000,
                      PerformanceRate = 99,
                      Specialization = "Dentist"
                  },
                  new Doctor
                  {
                      Id = Guid.NewGuid(),
                      Name = "MOhammed",
                      Salary = 95000,
                      PerformanceRate = 80,
                      Specialization = "opthomalogy"
                  },
                  new Doctor
                  {
                      Id = Guid.NewGuid(),
                      Name = "Nader",
                      Salary = 75000,
                      PerformanceRate = 100,
                      Specialization = "Pediartics"
                  }


                );
            #endregion


        }
    }
}

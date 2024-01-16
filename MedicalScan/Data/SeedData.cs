using MedicalScan.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicalScan.Data
{
    public class SeedData
    {
        private readonly MyDbContext myDbContext;

        public SeedData(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public void Seed()
        {
            if (!myDbContext.Specialities.Any())
            {
                var specialities = new[]
                {
            new Speciality { Name = "Cardiology" },
            new Speciality { Name = "Dermatology" },
        };

                myDbContext.Specialities.AddRange(specialities);
                myDbContext.SaveChanges();
            }

            if (!myDbContext.Doctors.Any())
            {
                var doctors = new[]
                {
            new Doctor { Name = "Dr. Gipsz Jakab" },
            new Doctor { Name = "Dr. Teszt Elek" },
            new Doctor { Name = "Dr. Kedvező Áron" },
            new Doctor { Name = "Dr. Gipsz Elek" },
            new Doctor { Name = "Dr. Doktor Doloróza" }
        };

                myDbContext.Doctors.AddRange(doctors);
                myDbContext.SaveChanges();

                // Now, create associations in the junction table
                var doctorSpecialties = new[]
                {
            new DoctorSpeciality { DoctorId = 1, SpecialityId = 1 }, 
            new DoctorSpeciality { DoctorId = 2, SpecialityId = 2 }, 
            new DoctorSpeciality { DoctorId = 3, SpecialityId = 1 }, 
            new DoctorSpeciality { DoctorId = 4, SpecialityId = 2 }, 
            new DoctorSpeciality { DoctorId = 5, SpecialityId = 1 }  
        };

                myDbContext.DoctorSpecialties.AddRange(doctorSpecialties);
                myDbContext.SaveChanges();
            }
        }

    }



}


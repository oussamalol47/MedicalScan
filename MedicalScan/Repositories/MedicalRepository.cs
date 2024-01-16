using MedicalScan.Data;
using MedicalScan.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MedicalScan.Repositories
{
    public class MedicalRepository : IMedicalRepository
    {
        private readonly MyDbContext _context;

        public MedicalRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Speciality> GetSpecialities()
        {
            return _context.Specialities.ToList();
        }

        public List<Doctor> GetDoctorsWithSpecialities()
        {
            return _context.Doctors.Include(d => d.DoctorSpecialities).ThenInclude(ds => ds.Speciality).ToList();
        }

        public List<Doctor> GetFilteredDoctors(int selectedSpecialtyId)
        {
            var doctors = GetDoctorsWithSpecialities();
            if (selectedSpecialtyId != 0)
            {
                doctors = doctors.Where(d => d.DoctorSpecialities.Any(ds => ds.SpecialityId == selectedSpecialtyId)).ToList();
            }

            return doctors;
        }
    }

}

using MedicalScan.Models;
using System.Collections.Generic;

namespace MedicalScan.Repositories
{
    public interface IMedicalRepository
    {
        List<Speciality> GetSpecialities();
        List<Doctor> GetDoctorsWithSpecialities();
        List<Doctor> GetFilteredDoctors(int selectedSpecialtyId);
    }
}

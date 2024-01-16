using System.Collections.Generic;

namespace MedicalScan.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DoctorSpeciality> DoctorSpecialities { get; set; }
    }
}

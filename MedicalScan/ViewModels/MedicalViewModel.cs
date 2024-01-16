using MedicalScan.Models;
using System.Collections.Generic;

namespace MedicalScan.ViewModels
{
    public class MedicalViewModel
    {
        public List<Speciality> Specialities { get; set; }
        public int SelectedSpecialtyId { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}

using MedicalScan.Data;
using MedicalScan.Models;
using MedicalScan.Repositories;
using MedicalScan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalScan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMedicalRepository _medicalRepository;

        public HomeController(ILogger<HomeController> logger, IMedicalRepository medicalRepository)
        {
            _logger = logger;
            _medicalRepository = medicalRepository;
        }

        public IActionResult Index()
        {
            var specialties = _medicalRepository.GetSpecialities();
            var doctors = _medicalRepository.GetDoctorsWithSpecialities();

            var viewModel = new MedicalViewModel
            {
                Specialities = specialties,
                SelectedSpecialtyId = 0, // Default to "All"
                Doctors = doctors
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FilterDoctors(int selectedSpecialtyId)
        {
            var specialties = _medicalRepository.GetSpecialities();
            var doctors = _medicalRepository.GetFilteredDoctors(selectedSpecialtyId);

            var viewModel = new MedicalViewModel
            {
                Specialities = specialties,
                SelectedSpecialtyId = selectedSpecialtyId,
                Doctors = doctors
            };

            return PartialView("_DoctorsPartial", viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

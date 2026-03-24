using HospitalSystem.DataAccess;
using HospitalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HospitalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookAppointment(string searchName, string specialization, int page = 1)
        {
            var doctors = _context.Doctors.AsQueryable();
            if (!string.IsNullOrEmpty(searchName))
            {
                doctors = doctors.Where(d => d.Name.ToLower().Contains(searchName.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(specialization))
            {
                doctors = doctors.Where(d => d.Specialization.ToLower().Contains(specialization.Trim().ToLower()));
            }
            int pageSize = 6;
            int totalDoctors = doctors.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalDoctors / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchName = searchName;
            ViewBag.Specialization = specialization;
            ViewBag.Specializations = _context.Doctors
                                      .Select(d => d.Specialization)
                                      .Distinct()
                                      .ToList();
            doctors = doctors.Skip((page-1)* pageSize).Take(pageSize);
            return View(doctors.AsEnumerable());
        }

        public IActionResult CompleteAppointment(int doctorId)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == doctorId);
            return View(doctor);
        }
        
        [HttpPost]
        public IActionResult CreateAppointment(int DoctorId,string PatientName,
                        DateTime AppointmentDate,string AppointmentTime)
        {
            
            DateTime fullDateTime = DateTime.Parse($"{AppointmentDate:yyyy-MM-dd} {AppointmentTime}");

            
            bool exists = _context.Appointments.Any(a =>
                a.DoctorId == DoctorId &&
                a.AppointmentDateTime == fullDateTime);

            if (exists)
            {
                ModelState.AddModelError("", "This time slot is already booked.");
                var doctor = _context.Doctors.FirstOrDefault(d => d.Id == DoctorId);
                return View("CompleteAppointment", doctor); 
            }

            var appointment = new Appointment
            {
                DoctorId = DoctorId,
                PatientName = PatientName,
                AppointmentDateTime = fullDateTime
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return View();
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
        public JsonResult GetBookedSlots(int doctorId, DateTime date)
        {
            var bookedTimes = _context.Appointments
                .Where(a => a.DoctorId == doctorId &&
                            a.AppointmentDateTime.Date == date.Date)
                .Select(a => a.AppointmentDateTime.ToString("HH:mm"))
                .ToList();

            return Json(bookedTimes);
        }
        public IActionResult AllAppointments(string? searchName, string? specialization, int page = 1)
        {
            var appointments = _context.Appointments.Include(e => e.Doctor).AsQueryable();
            if (!string.IsNullOrEmpty(searchName))
            {
                appointments = appointments.Where(d => d.Doctor.Name.ToLower().Contains(searchName.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(specialization))
            {
                appointments = appointments.Where(d => d.Doctor.Specialization.ToLower().Contains(specialization.Trim().ToLower()));
            }
            int pageSize = 6;
            int totalappointments = appointments.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalappointments / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchName = searchName;
            ViewBag.Specialization = specialization;
            ViewBag.Specializations = _context.Doctors
                                      .Select(d => d.Specialization)
                                      .Distinct()
                                      .ToList();
            appointments = appointments.Skip((page - 1) * pageSize).Take(pageSize);

            return View(appointments.AsEnumerable());
        }
    }
}

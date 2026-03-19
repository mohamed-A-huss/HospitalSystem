using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime AppointmentDateTime { get; set; }
        [Required]
        public int DoctorId { get; set; } 

        public Doctor Doctor { get; set; } = null!;
        public string PatientName { get; set; } = null!;
        
    }
}

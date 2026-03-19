using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Specialization { get; set; } = null!;


        public ICollection<Appointment>? Appointments { get; set; } 
    }
}


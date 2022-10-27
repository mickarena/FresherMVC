using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class HospitalBed : BaseEntity
    {
        [Required(ErrorMessage = "Room ID cannot be empty")]
        public string IDRoom { get; set; }
        [Required(ErrorMessage = "Parient ID cannot be empty")]
        public string IDPatient { get; set; }
        public bool Status { get; set; }
    }
}
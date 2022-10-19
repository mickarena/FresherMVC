using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class WorkShift : BaseEntity
    {
        [Required(ErrorMessage = "You haven't selected a shift yet")]
        [ForeignKey("Shift")]
        public Guid IdShift { get; set; }
        [Required(ErrorMessage = "You haven't chosen a doctor yet")]
        [ForeignKey("Doctor")]
        public Guid IdDoctor { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You haven't chosen a working day")]
        public DateTime? Date { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public Shift? Shift { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
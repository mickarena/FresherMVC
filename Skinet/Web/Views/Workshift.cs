using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class WorkShift : BaseEntity
    {
        [Required(ErrorMessage = "You haven't selected a shift yet")]
        public Guid IdShift { get; set; }
        [Required(ErrorMessage = "You haven't chosen a doctor yet")]
        public Guid IdDoctor { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You haven't chosen a working day")]
        public DateTime? Date { get; set; }
        public DateTime CreateAt { get; set; }
        public Shift? Shift { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
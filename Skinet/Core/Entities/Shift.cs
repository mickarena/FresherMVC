using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Shift : BaseEntity
    {
        [Column(TypeName = "NVARCHAR(30)")]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$", ErrorMessage = "Input is incorrect, ex: First Shift")]
        [Required(ErrorMessage = "The name of the shift cannot be empty")]
        public string? ShiftName { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You have not selected a work start time")]
        public DateTime? StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You have not selected a work end time")]
        public DateTime? EndTime { get; set; }
        public ICollection<WorkShift>? WorkShift { get; set; }
    }
}
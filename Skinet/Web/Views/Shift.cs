using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Shift : BaseEntity
    {
        [Column(TypeName = "NVARCHAR(30)")]
        [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$", ErrorMessage = "Input is incorrect, ex: First Shift")]
        [StringLength(30)]
        [Required(ErrorMessage = "The name of the shift cannot be empty")]
        public string? ShiftName { get; set; }

        [Column(TypeName = "VARCHAR(5)")]
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Input is incorrect, ex: 12:59")]
        [StringLength(5, MinimumLength = 5)]
        [Required(ErrorMessage = "You have not selected a work start time")]
        public string? StartTime { get; set; }

        [Column(TypeName = "VARCHAR(5)")]
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Input is incorrect, ex: 12:59")]
        [StringLength(5, MinimumLength = 5)]
        [Required(ErrorMessage = "You have not selected a work end time")]
        public string? EndTime { get; set; }
        public ICollection<WorkShift>? WorkShift { get; set; }
    }
}
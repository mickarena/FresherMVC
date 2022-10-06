using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Shift
    {
        public Guid IdShift { get; set; }
        [Column(TypeName = "NVARCHAR(30)")]
        [RegularExpression(@"^([A-z][A-Za-z]*\s+[A-Za-z]*)|([A-z][A-Za-z]*)$", ErrorMessage = "Nhâp không đúng")]
        [StringLength(30)]
        [Required(ErrorMessage = "The name of the shift cannot be empty")]
        public string? ShiftName { get; set; }
        [Required(ErrorMessage = "You have not selected a work start time")]
        public string? StartTime { get; set; }
        [Required(ErrorMessage = "You have not selected a work end time")]
        public string? EndTime { get; set; }
        public ICollection<WorkShift> WorkShift { get; set; }
    }
}
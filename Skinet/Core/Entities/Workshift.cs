using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WorkShift
    {
        public Guid IdWork { get; set; }
        [Required(ErrorMessage = "You haven't selected a shift yet")]
        public Guid IdShift { get; set; }
        [Required(ErrorMessage = "You haven't chosen a doctor yet")]
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public DateTime? CreateAt { get; set; }
        public Shift? Shift { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
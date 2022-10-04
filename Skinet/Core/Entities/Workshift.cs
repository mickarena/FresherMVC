using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WorkShift : BaseEntity
    {
        public Guid IdDoctor { get; set; }
        public Guid IdShift { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public string? Status { get; set; }

        public Shift? Shift { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Shift
    {
        public int IdShift { get; set; }
        [Column(TypeName = "NVARCHAR(30)")]
        public string? ShiftName { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public ICollection<WorkShift> WorkShift { get; set; }
    }
}
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Shift : BaseEntity
    {
        public Guid IdShift { get; set; }
        public string? ShiftName { get; set; }
        public string? Time { get; set; }
        public ICollection<WorkShift> WorkShift { get; set; }
    }
}
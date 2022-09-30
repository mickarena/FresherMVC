﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Shift
    {
        public int Id { get; set; }
        public int IdShift { get; set; }
        public string? NameShift { get; set; }
        public string? Time { get; set; }

        public ICollection<WorkShift> WorkShifts { get; set; }
    }
}

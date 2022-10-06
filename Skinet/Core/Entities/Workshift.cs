﻿using System;
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
        public Guid IdShift { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string DoctorName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string? Status { get; set; }
        public Shift? Shift { get; set; }
    }
}
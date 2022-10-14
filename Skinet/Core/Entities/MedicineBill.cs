﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MedicineBill : BaseEntity
    {
        [Required]
        public Guid DoctorID { get; set; }

        public DateTime DateCreate { get; set; }

        [Required]
        public bool PayStatus { get; set; }

        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}
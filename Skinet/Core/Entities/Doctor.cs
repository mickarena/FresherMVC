﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Doctor : BaseEntity
    {
        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Address { get; set; }
        public Gender Gender { get; set; }      
        public DateTime Birthday { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Department { get; set; }
    }
}


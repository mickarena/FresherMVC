﻿using Microsoft.AspNetCore.Http;
using System;
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
        public string Name { get; set; }
        public string Phone { get; set; }
       
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Department { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [Display(Name = "Upload File")]
        public IFormFile ImageFile { get; set; }
        public ICollection<WorkShift> WorkShift { get; set; }
    }
}
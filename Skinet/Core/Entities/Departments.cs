﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Departments
    {
        public Departments()
        {
            this.Nurses = new HashSet<Nurse>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? JoinDate { get; set; }


            public virtual ICollection<Nurse> Nurses { get; set; }
    
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class HospitalBed : BaseEntity
    {
        public int IDRoom { get; set; }
        public int IDPatient { get; set; }
        public bool Status { get; set; }
    }
}
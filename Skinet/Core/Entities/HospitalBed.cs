using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class HospitalBed:BaseEntity
    {
        public bool Status { get; set; }
        public int IdRoom { get; set; }
        public int IdPatient { get; set; }
    }
}

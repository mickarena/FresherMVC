using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
<<<<<<< HEAD
    public class HospitalBed : BaseEntity
    {
        public int IDRoom { get; set; }
        public int IDPatient { get; set; }
        public bool Status { get; set; }
    }
}
=======
    public class HospitalBed:BaseEntity
    {
        public bool Status { get; set; }
        public int IdRoom { get; set; }
        public int IdPatient { get; set; }
    }
}
>>>>>>> d6018042699817871a98843e6136829e8d5aa225

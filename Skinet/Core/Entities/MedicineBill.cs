
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MedicineBill : BaseEntity
    {
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public DateTime DateCreate { get; set; }
        public bool PayStatus { get; set; }

        public IEnumerable<MedicineBillInfo>? MedicineBillInfo { get; set; }
    }
}


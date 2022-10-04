using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class MedicineBill : BaseEntity
    {
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }

        [Required]
        public DateTime DateCreate { get; set; } = DateTime.UtcNow;

        [Required]
        public bool PayStatus { get; set; }

        public IEnumerable<MedicineBillInfo>? MedicineBillInfo { get; set; }
    }
}
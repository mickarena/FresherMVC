using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class MedicineInfomation : BaseEntity
    {
        public Guid MedicineIDType { get; set; }

        [Required]
        public DateTime ImportDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitPrice { get; set; }

        [Required]
        public bool IsEmpty { get; set; }

        public MedicineType? MedicineType { get; set; }
        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}
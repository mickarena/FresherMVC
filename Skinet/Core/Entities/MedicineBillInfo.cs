using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class MedicineBillInfo : BaseEntity
    {
        public Guid MedicineBillID { get; set; }
        public Guid IdMedicineInfo { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        public MedicineInfomation? MedicineInfomation { get; set; }
        public MedicineBill? MedicineBills { get; set; }
    }
}
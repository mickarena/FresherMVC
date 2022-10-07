
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MedicineBillInfo : BaseEntity
    {
        public Guid BillId { get; set; }
        public Guid IdMedicineInfo { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Price { get; set; }

        public MedicineInfomation? MedicineInfomation { get; set; }
        public MedicineBill? MedicineBills { get; set; }
    }
}
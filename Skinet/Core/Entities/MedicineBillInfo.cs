﻿using System.ComponentModel;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineBillInfo : BaseEntity
    {
        [Required]
        [DisplayName("Bill ID")]
        public Guid MedicineBillID { get; set; }

        [Required]
        [DisplayName("Medicine Name")]
        public Guid IdMedicineInfo { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [MaxLength(50)]
        [Range(0, int.MaxValue)]
        [DisplayName("Unit price")]
        public int UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        [MaxLength(50)]
        [DisplayName("Total price")]
        public int Price { get; set; }

        public MedicineInfomation? MedicineInfomations { get; set; }
        public MedicineBill? MedicineBills { get; set; }
    }
}
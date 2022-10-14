<<<<<<< HEAD
using Core.Entities;
using System;
using System.Collections.Generic;
=======
using System.ComponentModel;
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineInfomation : BaseEntity
    {
        [Required]
        [DisplayName("Medicine type")]
        public Guid MedicineIDType { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Medicine name")]
        public string Name { get; set; }

        [DisplayName("Import date")]
        public DateTime ImportDate { get; set; }

        [Required]
        [DisplayName("Expire date")]
        public DateTime ExpireDate { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Unit price")]
        [Required]
        public int UnitPrice { get; set; }

        [Required]
        [DisplayName("Status")]
        public bool IsEmpty { get; set; }

        public MedicineType? MedicineTypes { get; set; }
        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}
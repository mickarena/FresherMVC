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
    public class MedicineType : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string? Name { get; set; }

        public IEnumerable<MedicineInfomation>? MedicineInfomations { get; set; }
    }
}
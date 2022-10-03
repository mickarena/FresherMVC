using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class MedicineType : BaseEntity
    {
        [Required]
        public string? Name { get; set; }

        public IEnumerable<MedicineInfomation>? MedicineInfomations { get; set; }
    }
}
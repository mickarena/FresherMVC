using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Departments : BaseEntity
    {
        [Required(ErrorMessage = "Nhập tên phòng ban")]
        [StringLength(100)]
        public string? Name { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? JoinDate { get; set; }

        public ICollection<Nurse>? Nurses { get; set; }

    }
}

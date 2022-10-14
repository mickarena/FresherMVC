using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Nurse : BaseEntity
    {
        [Required(ErrorMessage = "Nhập tên điều dưỡng")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [Phone]
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public Guid DepartmentId { get; set; }
        public Departments? Departments { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? JoinDate { get; set; }

        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Entities
{
    public class Nurse : BaseEntity
    {
        [Required(ErrorMessage = "Enter the nurse's name")]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Enter phone number")]
        [Display(Name = "Phone Nmber")]
        [Phone]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string? Address { get; set; }
        public Guid DepartmentId { get; set; }
        public Department? Departments { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}

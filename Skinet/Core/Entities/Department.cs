using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Department : BaseEntity
    {
        [Required(ErrorMessage = "Enter Name Department")]
        [StringLength(100)]
        public string? Name { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public ICollection<Nurse>? Nurses { get; set; }
    }
}

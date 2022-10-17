using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Doctor : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string Department { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [Display(Name = "Upload File")]
        public IFormFile ImageFile { get; set; }
        public ICollection<WorkShift> WorkShift { get; set; }
    }
}
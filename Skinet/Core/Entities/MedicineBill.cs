using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineBill : BaseEntity
    {
        [Required]
        public Guid DoctorID { get; set; }

        public DateTime DateCreate { get; set; }

        [Required]
        public bool PayStatus { get; set; }

        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}
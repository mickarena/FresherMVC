using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineBill : BaseEntity
    {
        [Required]
        [DisplayName("Doctor ID")]
        public Guid DoctorID { get; set; }

        [DisplayName("Date created")]
        public DateTime DateCreate { get; set; }

        [Required]
        [DisplayName("Pay status")]
        public bool PayStatus { get; set; }

        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}
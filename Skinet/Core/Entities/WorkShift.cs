using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class WorkShift : BaseEntity
    {
        public Guid IdDoctor { get; set; }
        public Guid IdShift { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string? Status { get; set; }

        public Shift? Shift { get; set; }
        public Doctor? Doctor { get; set; }
    }
}

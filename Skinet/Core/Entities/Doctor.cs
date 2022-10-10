using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Doctor : BaseEntity
    {
        public Guid IdDoctor { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public ICollection<WorkShift> WorkShift { get; set; }
    }
}
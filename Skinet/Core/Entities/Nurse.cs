using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Nurse : BaseEntity
    {
        public string? Name { get; set; }
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

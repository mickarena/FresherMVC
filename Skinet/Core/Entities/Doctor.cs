using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Department { get; set; }
        
    }
}

namespace Core
{
    public enum Gender
    {
        Male, Female, Other
    }
}
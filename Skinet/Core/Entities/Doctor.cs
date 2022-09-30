using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //public enum Sex
    //{
    //    Male, Female, Other
    //}
    public class Doctor
    {
        
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public int IdDoctor { get; set; }
        public string? Name { get; set; }
        public string? Sex { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Status { get; set; }
        public ICollection<WorkShift> WorkShifts { get; set; }
    }
}

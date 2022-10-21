using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class HospitalBed : BaseEntity
    {
        [Required(ErrorMessage = "Room ID cannot be empty")]
        public string IDRoom { get; set; }
        [Required(ErrorMessage = "Parient ID cannot be empty")]
        public string IDPatient { get; set; }
        public bool Status { get; set; }
        
    }
}
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
        [Required(ErrorMessage ="ID phòng không để trống")]
        public string IDRoom { get; set; }
        [Required(ErrorMessage = "ID bệnh nhân không để trống")]
        public string IDPatient { get; set; }
        public bool Status { get; set; }
    }
}


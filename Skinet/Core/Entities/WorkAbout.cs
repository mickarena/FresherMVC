using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WorkAbout
    {
        public Guid IdShift { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int Count { get; set; }
    }
}

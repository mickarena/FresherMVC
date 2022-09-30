using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //public enum Status
    //{
    //    DungGio, Muon, KhongDen, ChuaDenLich
    //}
    public class WorkShift
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public int IdShift { get; set; }
        public DateTime? Day { get; set; }
        public string? Status { get; set; }
        public Doctor? Doctor { get; set; }
        public Shift? Shift { get; set; }
    }
}

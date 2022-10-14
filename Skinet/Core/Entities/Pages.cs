using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Pages
    {

        public List<Departments>? Departments { get; set; }

        public List<Nurse>? Nurses { get; set; }

        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }



      

}
}

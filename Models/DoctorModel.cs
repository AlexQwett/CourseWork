using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Abstract;

namespace Models
{
    public class DoctorModel : BaseClass
    {
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public int OfficeNumber { get; set; }
    }
}

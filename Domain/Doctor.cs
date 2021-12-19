using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;

namespace Domain
{
    public class Doctor : BaseClass
    {
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public int OfficeNumber { get; set; }
    }
}

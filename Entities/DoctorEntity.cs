using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities
{
    public class DoctorEntity : BaseEntity
    {
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public int OfficeNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain;

namespace Domain
{
    public class Patient : BaseClass
    {
        public string Disease { get; set; }
        public string DetectionDate { get; set; }
        public List<MedicalBookNote> MedicalBook { get; set; }
    }
}

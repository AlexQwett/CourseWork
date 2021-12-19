using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Abstract;

namespace Models
{
    public class PatientModel : BaseClass
    {
        public string Disease { get; set; }
        public string DetectionDate { get; set; }
        public List<MedicalBookNoteModel> MedicalBook { get; set; }
    }
}

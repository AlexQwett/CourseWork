using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ScheduleNoteEntity
    {
        public int ID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Time { get; set; }
        public PatientEntity Patient { get; set; }
        public DoctorEntity Doctor { get; set; }
    }
}

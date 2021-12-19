using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ScheduleModel
    {
        public DateTime AdmissionDate { get; set; }
        public string Time { get; set; }
        public PatientModel Patient { get; set; }
        public DoctorModel Doctor { get; set; }
    }
}

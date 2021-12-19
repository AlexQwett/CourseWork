using System;
using System.Collections.Generic;

namespace Domain
{
    public class ScheduleNote
    {
        public int ID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Time { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}

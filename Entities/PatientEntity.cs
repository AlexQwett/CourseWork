using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class PatientEntity : BaseEntity
    {
        public string Disease { get; set; }
        public string DetectionDate { get; set; }
        public List<MedicalBookNoteEntity> MedicalBook { get; set; }
    }
}

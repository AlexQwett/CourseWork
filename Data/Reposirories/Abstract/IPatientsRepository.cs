using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Reposirories.Abstract
{
    interface IPatientsRepository
    {
        void AddPatient(PatientEntity patient);
        void UpdatePatient(PatientEntity patient);
        List<PatientEntity> GetPatients();
        void DeletePatient(PatientEntity patient);
    }
}

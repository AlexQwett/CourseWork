using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Reposirories.Abstract;
using Entities;
using Newtonsoft.Json;

namespace Data.Reposirories
{
    public class PatientsRepository : IPatientsRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\CourseworkVar13\Data\DataBases\patients.json";
        private static string json = File.ReadAllText(path);
        private static List<PatientEntity> _patients = new List<PatientEntity>();

        public void AddPatient(PatientEntity patient)
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<PatientEntity>>(json);

            if (_patients == null)
            {
                _patients = new List<PatientEntity>();
                patient.ID = 0;
            }
            else
            {
                patient.ID = _patients.Count;
            }

            _patients.Add(patient);

            File.WriteAllText(path, JsonConvert.SerializeObject(_patients, Formatting.Indented));
        }

        public void DeletePatient(PatientEntity patient)
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<PatientEntity>>(json);

            _patients.RemoveAt(patient.ID);

            for (int i = 0; i < _patients.Count; i++)
            {
                if (_patients[i].ID > patient.ID)
                {
                    _patients[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_patients, Formatting.Indented));
        }

        public List<PatientEntity> GetPatients()
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<PatientEntity>>(json);

            if (_patients == null)
                _patients = new List<PatientEntity>();

            return _patients;
        }

        public void UpdatePatient(PatientEntity patient)
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<PatientEntity>>(json);

            _patients[patient.ID] = patient;
            File.WriteAllText(path, JsonConvert.SerializeObject(_patients, Formatting.Indented));
        }
    }
}

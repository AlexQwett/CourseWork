using System;
using System.Collections.Generic;
using System.IO;
using Data.Reposirories.Abstract;
using Entities;
using Newtonsoft.Json;

namespace Data.Reposirories
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\CourseworkVar13\Data\DataBases\doctors.json";
        private static string json = File.ReadAllText(path);
        private List<DoctorEntity> _doctors = new List<DoctorEntity>();

        public void AddDoctor(DoctorEntity doctor)
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<DoctorEntity>>(json);

            if (_doctors == null)
            {
                _doctors = new List<DoctorEntity>();
                doctor.ID = 0;
            }
            else
            {
                doctor.ID = _doctors.Count;
            }

            _doctors.Add(doctor);

            File.WriteAllText(path, JsonConvert.SerializeObject(_doctors, Formatting.Indented));
        }

        public void DeleteDoctor(DoctorEntity doctor)
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<DoctorEntity>>(json);

            _doctors.RemoveAt(doctor.ID);

            for (int i = 0; i < _doctors.Count; i++)
            {
                if (_doctors[i].ID > doctor.ID)
                {
                    _doctors[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_doctors, Formatting.Indented));
        }

        public List<DoctorEntity> GetDoctors()
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<DoctorEntity>>(json);

            if (_doctors == null)
                _doctors = new List<DoctorEntity>();

            return _doctors;
        }

        public void UpdateDoctor(DoctorEntity doctor)
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<DoctorEntity>>(json);

            _doctors[doctor.ID] = doctor;

            File.WriteAllText(path, JsonConvert.SerializeObject(_doctors, Formatting.Indented));
        }
    }
}

using System;
using System.Collections.Generic;
using Domain;
using Data.Reposirories;
using Mapper;

namespace Services
{
    public class PatientsService
    {
        private static PatientsRepository patientsRepository = new PatientsRepository();
        private List<Patient> _patients = patientsRepository.GetPatients().ToDomainList();

        public void AddOrUpdatePatient(Patient patient)
        {
            bool toUpdate = false;

            foreach (var DBPatient in _patients)
            {
                if (DBPatient.IdentificationCode == patient.IdentificationCode)
                {
                    toUpdate = true;
                }
            }

            if (toUpdate == true)
                patientsRepository.UpdatePatient(patient.ToEntity());
            else
                patientsRepository.AddPatient(patient.ToEntity());
        }

        public bool DeletePatient(string id)
        {
            try
            {
                _patients = patientsRepository.GetPatients().ToDomainList();
                Patient patientToDelete = _patients.Find(patient => patient.IdentificationCode == id || patient.IdentificationCode == id);

                if (patientToDelete == null)
                {
                    throw new Exception("Об'єкта не існує");
                }
                else
                {
                    patientsRepository.DeletePatient(patientToDelete.ToEntity());
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Patient GetPatient(string id)
        {
            try
            {
                _patients = patientsRepository.GetPatients().ToDomainList();
                Patient findedPatient = _patients.Find(patient => patient.IdentificationCode == id || patient.IdentificationCode == id);

                if (findedPatient == null)
                    throw new Exception("Об'єкта не існує");
                else
                    return findedPatient;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Patient> GetPatients()
        {
            _patients = patientsRepository.GetPatients().ToDomainList();

            return _patients;
        }

        public List<MedicalBookNote> GetMedicalBook(string id)
        {
            _patients = patientsRepository.GetPatients().ToDomainList();

            return GetPatient(id).MedicalBook;
        }

        public void AddMedicalBookNote(string id, MedicalBookNote note)
        {
            _patients = patientsRepository.GetPatients().ToDomainList();

            Patient patient = GetPatient(id);

            patient.MedicalBook.Add(note);

            AddOrUpdatePatient(patient);
        }
    }
}

using System;
using System.Collections.Generic;
using Domain;
using Data.Reposirories;
using Mapper;

namespace Services
{
    public class DoctorsService
    {
        private static readonly DoctorsRepository doctorsRepository = new DoctorsRepository();
        private List<Doctor> _doctors = doctorsRepository.GetDoctors().ToDomainList();

        public void AddOrUpdateDoctor(Doctor doctor)
        {
            bool toUpdate = false;

            foreach (var DBDoctor in _doctors)
            {
                if (DBDoctor.IdentificationCode == doctor.IdentificationCode)
                {
                    toUpdate = true;
                }
            }

            if (toUpdate == true)
                doctorsRepository.UpdateDoctor(doctor.ToEntity());
            else
                doctorsRepository.AddDoctor(doctor.ToEntity());
        }

        public bool DeleteDoctor(string id)
        {
            try
            {
                _doctors = doctorsRepository.GetDoctors().ToDomainList();
                Doctor doctorToDelete = _doctors.Find(doctor => doctor.IdentificationCode == id);

                if (doctorToDelete == null)
                {
                    throw new Exception("Об'єкта не існує");
                }
                else
                {
                    doctorsRepository.DeleteDoctor(doctorToDelete.ToEntity());
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Doctor GetDoctor(string id)
        {
            try
            {
                _doctors = doctorsRepository.GetDoctors().ToDomainList();
                Doctor findedDoctor = _doctors.Find(doctor => doctor.IdentificationCode == id);

                if (findedDoctor == null)
                    throw new Exception("Об'єкта не існує");
                else
                    return _doctors.Find(doctor => doctor.IdentificationCode == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Doctor GetDoctorByQualification(string qualification)
        {
            try
            {
                _doctors = doctorsRepository.GetDoctors().ToDomainList();
                Doctor findedDoctor = _doctors.Find(doctor => doctor.Qualification == qualification);

                if (findedDoctor == null)
                    throw new Exception("Об'єкта не існує");
                else
                    return _doctors.Find(doctor => doctor.Qualification == qualification);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Doctor> GetDoctorsList()
        {
            _doctors = doctorsRepository.GetDoctors().ToDomainList();

            return _doctors;
        }
    }
}

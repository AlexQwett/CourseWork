using System;
using System.Collections.Generic;
using Services;
using Mapper;
using Models;

namespace API.Controllers
{
    public class DoctorsController
    {
        private DoctorsService doctorsService = new DoctorsService();

        public void AddOrUpdateDoctor(string Name, string LastName, int Age, string Email, string IdentificationCode, string Qualification, int Experience, int OfficeNumber)
        {
            DoctorModel doctor = new DoctorModel
            {
                Name = Name,
                LastName = LastName,
                Age = Age,
                Email = Email,
                IdentificationCode = IdentificationCode,
                Qualification = Qualification,
                Experience = Experience,
                OfficeNumber = OfficeNumber
            };

            doctorsService.AddOrUpdateDoctor(doctor.ToDomain());
        }

        public bool DeleteDoctor(string id)
        {
            return doctorsService.DeleteDoctor(id);
        }

        public DoctorModel GetDoctor(string id)
        {
            if (doctorsService.GetDoctor(id) == null)
            {
                return null;
            }

            return doctorsService.GetDoctor(id).ToModel();
        }

        public DoctorModel GetDoctorByQualification(string qualification)
        {
            if (doctorsService.GetDoctorByQualification(qualification) == null)
            {
                return null;
            }

            return doctorsService.GetDoctorByQualification(qualification).ToModel();
        }

        public string GetDoctorInfo(string id)
        {
            DoctorModel doctor = GetDoctor(id);

            if (doctor == null)
            {
                return "Лікаря за даним ідентифікаційним кодом не існує";
            }

            return $"Ім'я: {doctor.Name}\n" +
                   $"Прізвище: {doctor.LastName}\n" +
                   $"Вік: {doctor.Age}\n" +
                   $"Електронна пошта: {doctor.Email}\n" +
                   $"Ідентифікаційний код: {doctor.IdentificationCode}\n" +
                   $"Кваліфікація лікаря: {doctor.Qualification}\n" +
                   $"Стаж роботи: {doctor.Experience}\n" +
                   $"Номер кабінету: {doctor.OfficeNumber}\n";
        }

        public List<DoctorModel> GetDoctorsList()
        {
            return doctorsService.GetDoctorsList().ToModelList();
        }
    }
}

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

        public string AddOrUpdateDoctor(string Name, string LastName, int Age, string Email, string IdentificationCode, string Qualification, int Experience, int OfficeNumber)
        {
            try
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

                return "Дані оновлено\n";
            }
            catch (Exception)
            {
                return "Щось пішло не так, перевірте корректність вводу даних\n";
            }
        }

        public string DeleteDoctor(string id)
        {
            if (doctorsService.DeleteDoctor(id))
                return "Дані лікаря успішно видалено";
            else
                return "Лікаря не знайдено";
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

        public string GetDoctorsInfo()
        {
            List<DoctorModel> doctorModels = GetDoctorsList();

            string res = "";

            if (doctorModels.Count == 0)
            {
                return "База даних пуста";
            }

            foreach (var doctor in doctorModels)
            {
                res += GetDoctorInfo(doctor.IdentificationCode);

                if (doctorModels.Count != 1)
                    res += "-------------------------\n\n";
            }

            return res;
        }

        public List<DoctorModel> GetDoctorsList()
        {
            return doctorsService.GetDoctorsList().ToModelList();
        }
    }
}

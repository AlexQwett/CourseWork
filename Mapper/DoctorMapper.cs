using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Domain;
using Models;

namespace Mapper
{
    public static class DoctorMapper
    {
        public static DoctorEntity ToEntity(this Doctor doctor)
        {
            return new DoctorEntity
            {
                ID = doctor.ID,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Email = doctor.Email,
                IdentificationCode = doctor.IdentificationCode,
                Qualification = doctor.Qualification,
                Experience = doctor.Experience,
                OfficeNumber = doctor.OfficeNumber
            };
        }

        public static Doctor ToDomain(this DoctorEntity doctor)
        {
            return new Doctor
            {
                ID = doctor.ID,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Email = doctor.Email,
                IdentificationCode = doctor.IdentificationCode,
                Qualification = doctor.Qualification,
                Experience = doctor.Experience,
                OfficeNumber = doctor.OfficeNumber
            };
        }

        public static Doctor ToDomain(this DoctorModel doctor)
        {
            return new Doctor
            {
                Name = doctor.Name, 
                LastName = doctor.LastName,
                Age = doctor.Age,
                Email = doctor.Email,
                IdentificationCode = doctor.IdentificationCode,
                Qualification = doctor.Qualification,
                Experience = doctor.Experience,
                OfficeNumber = doctor.OfficeNumber
            };
        }

        public static List<Doctor> ToDomainList(this List<DoctorEntity> doctors)
        {
            List<Doctor> domainClients = new List<Doctor>();

            if (doctors == null)
            {
                return domainClients;
            }

            foreach (var doctor in doctors)
            {
                domainClients.Add(new Doctor()
                {
                    ID = doctor.ID,
                    Name = doctor.Name,
                    LastName = doctor.LastName,
                    Age = doctor.Age,
                    Email = doctor.Email,
                    IdentificationCode = doctor.IdentificationCode,
                    Qualification = doctor.Qualification,
                    Experience = doctor.Experience,
                    OfficeNumber = doctor.OfficeNumber
                });
            }

            return domainClients;
        }

        public static List<DoctorModel> ToModelList(this List<Doctor> doctors)
        {
            List<DoctorModel> modelsDoctors = new List<DoctorModel>();

            if (doctors == null)
            {
                return modelsDoctors;
            }

            foreach (var doctor in doctors)
            {
                modelsDoctors.Add(new DoctorModel()
                {
                    Name = doctor.Name,
                    LastName = doctor.LastName,
                    Age = doctor.Age,
                    Email = doctor.Email,
                    IdentificationCode = doctor.IdentificationCode,
                    Qualification = doctor.Qualification,
                    Experience = doctor.Experience,
                    OfficeNumber = doctor.OfficeNumber
                });
            }

            return modelsDoctors;
        }

        public static DoctorModel ToModel(this Doctor doctor)
        {
            return new DoctorModel
            {
                Name = doctor.Name,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Email = doctor.Email,
                IdentificationCode = doctor.IdentificationCode,
                Qualification = doctor.Qualification,
                Experience = doctor.Experience,
                OfficeNumber = doctor.OfficeNumber
            };
        }
    }
}

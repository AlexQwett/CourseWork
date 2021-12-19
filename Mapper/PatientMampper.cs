using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Entities;
using Models;
using Mapper;

namespace Mapper
{
    public static class PatientMampper
    {
        public static PatientEntity ToEntity(this Patient patient)
        {
            return new PatientEntity
            {
                ID = patient.ID,
                Name = patient.Name,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                IdentificationCode = patient.IdentificationCode,
                Disease = patient.Disease,
                DetectionDate = patient.DetectionDate,
                MedicalBook = patient.MedicalBook.ToEntityList()
            };
        }

        public static Patient ToDomain(this PatientEntity patient)
        {
            return new Patient
            {
                ID = patient.ID,
                Name = patient.Name,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                IdentificationCode = patient.IdentificationCode,
                Disease = patient.Disease,
                DetectionDate = patient.DetectionDate,
                MedicalBook = patient.MedicalBook.ToDomainList()
            };
        }

        public static Patient ToDomain(this PatientModel patient)
        {
            return new Patient
            {
                Name = patient.Name,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                IdentificationCode = patient.IdentificationCode,
                Disease = patient.Disease,
                DetectionDate = patient.DetectionDate,
                MedicalBook = patient.MedicalBook.ToDomainList()
            };
        }

        public static List<Patient> ToDomainList(this List<PatientEntity> patients)
        {
            List<Patient> domainPatients = new List<Patient>();

            if (patients == null)
            {
                return domainPatients;
            }

            foreach (var patient in patients)
            {
                domainPatients.Add(new Patient()
                {
                    ID = patient.ID,
                    Name = patient.Name,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    Email = patient.Email,
                    IdentificationCode = patient.IdentificationCode,
                    Disease = patient.Disease,
                    DetectionDate = patient.DetectionDate,
                    MedicalBook = patient.MedicalBook.ToDomainList()
                });
            }

            return domainPatients;
        }

        public static List<PatientModel> ToModelList(this List<Patient> patients)
        {
            List<PatientModel> modelsPatients = new List<PatientModel>();

            if (patients == null)
            {
                return modelsPatients;
            }

            foreach (var patient in patients)
            {
                modelsPatients.Add(new PatientModel()
                {
                    Name = patient.Name,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    Email = patient.Email,
                    IdentificationCode = patient.IdentificationCode,
                    Disease = patient.Disease,
                    DetectionDate = patient.DetectionDate,
                    MedicalBook = patient.MedicalBook.ToModelList()
                });
            }

            return modelsPatients;
        }

        public static PatientModel ToModel(this Patient patient)
        {
            return new PatientModel
            {
                Name = patient.Name,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                IdentificationCode = patient.IdentificationCode,
                Disease = patient.Disease,
                DetectionDate = patient.DetectionDate,
                MedicalBook = patient.MedicalBook.ToModelList()
            };
        }
    }
}

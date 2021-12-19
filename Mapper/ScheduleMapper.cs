using System;
using System.Collections.Generic;
using Domain;
using Entities;
using Models;
using Mapper;

namespace Mapper
{
    public static class ScheduleMapper
    {
        public static ScheduleNoteEntity ToEntity(this ScheduleNote note)
        {
            return new ScheduleNoteEntity
            {
                ID = note.ID,
                AdmissionDate = note.AdmissionDate,
                Time = note.Time,
                Patient = note.Patient.ToEntity(),
                Doctor = note.Doctor.ToEntity()
            };
        }

        public static ScheduleNote ToDomain(this ScheduleNoteEntity note)
        {
            return new ScheduleNote
            {
                ID = note.ID,
                AdmissionDate = note.AdmissionDate,
                Time = note.Time,
                Patient = note.Patient.ToDomain(),
                Doctor = note.Doctor.ToDomain()
            };
        }

        public static ScheduleNote ToDomain(this ScheduleModel note)
        {
            return new ScheduleNote
            {
                AdmissionDate = note.AdmissionDate,
                Time = note.Time,
                Patient = note.Patient.ToDomain(),
                Doctor = note.Doctor.ToDomain()
            };
        }

        public static List<ScheduleNote> ToDomainList(this List<ScheduleNoteEntity> notes)
        {
            List<ScheduleNote> domainNotes = new List<ScheduleNote>();

            if (notes == null)
            {
                return domainNotes;
            }

            foreach (var note in notes)
            {
                domainNotes.Add(new ScheduleNote()
                {
                    ID = note.ID,
                    AdmissionDate = note.AdmissionDate,
                    Time = note.Time,
                    Patient = note.Patient.ToDomain(),
                    Doctor = note.Doctor.ToDomain()
                });
            }

            return domainNotes;
        }

        public static List<ScheduleModel> ToModelList(this List<ScheduleNote> notes)
        {
            List<ScheduleModel> modelsSchedule = new List<ScheduleModel>();

            if (notes == null)
            {
                return modelsSchedule;
            }

            foreach (var note in notes)
            {
                modelsSchedule.Add(new ScheduleModel()
                {
                    AdmissionDate = note.AdmissionDate,
                    Time = note.Time,
                    Patient = PatientMampper.ToModel(note.Patient),
                    Doctor = note.Doctor.ToModel()
                });
            }

            return modelsSchedule;
        }

        public static ScheduleModel ToModel(this ScheduleNote note)
        {
            return new ScheduleModel
            {
                AdmissionDate = note.AdmissionDate,
                Time = note.Time,
                Patient = PatientMampper.ToModel(note.Patient),
                Doctor = note.Doctor.ToModel()
            };
        }
    }
}

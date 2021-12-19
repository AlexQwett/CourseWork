using System;
using System.Collections.Generic;
using Mapper;
using Models;
using Services;

namespace API.Controllers
{
    public class ScheduleController
    {
        private ScheduleServices scheduleServices = new ScheduleServices();
        private PatientsController patientsController = new PatientsController();
        private DoctorsController doctorController = new DoctorsController();

        public bool AddNote(string date, string time, string patientID, string doctorQualification)
        {
            try
            {
                ScheduleModel scheduleModel = GetNote(date, time, patientID, doctorQualification);

                PatientModel patient = patientsController.GetPatient(patientID);
                DoctorModel doctor = doctorController.GetDoctorByQualification(doctorQualification);

                if (scheduleModel != null || patient == null || doctor == null)
                    return false;

                ScheduleModel schedule = new ScheduleModel
                {
                    AdmissionDate = DateTime.Parse(date),
                    Time = time,
                    Patient = patient,
                    Doctor = doctor
                };

                scheduleServices.AddNote(schedule.ToDomain());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ScheduleModel> GetNotes(string date)
        {
            DateTime dateTime = DateTime.Parse(date);

            List<ScheduleModel> models = scheduleServices.GetNotes(dateTime).ToModelList();

            if (models == null)
            {
                return null;
            }

            return models;
        }

        public bool DeleteNote(string date, string time, string patientID, string doctorQualification)
        {
            try
            {
                ScheduleModel scheduleModel = GetNote(date, time, patientID, doctorQualification);

                PatientModel patient = patientsController.GetPatient(patientID);
                DoctorModel doctor = doctorController.GetDoctorByQualification(doctorQualification);

                if (scheduleModel != null || patient == null || doctor == null)
                    return false;

                ScheduleModel schedule = new ScheduleModel
                {
                    AdmissionDate = DateTime.Parse(date),
                    Time = time,
                    Patient = patient,
                    Doctor = doctor
                };

                scheduleServices.DeleteNote(schedule.ToDomain());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetNotesInfo(string date)
        {
            List<ScheduleModel> notes = GetNotes(date);

            if(notes == null)
            {
                return "Записів в цей день немає";
            }

            string res = "";

            notes.Sort((first, second) => first.Time.CompareTo(second.Time));

            foreach (var note in notes)
            {   
                res += $"Дата і час: {note.AdmissionDate:dd.MM.yyyy} {note.Time} \n\n" +
                           $"Пацієнт: {patientsController.GetPatientInfo(note.Patient.IdentificationCode)}\n" +
                           $"Лікар: {doctorController.GetDoctorInfo(note.Doctor.IdentificationCode)}";
                
                if (notes.Count > 1)
                {
                    res += "\n-------------------\n\n";
                }
            }

            return res; 
        }

        public string GetNoteInfo(string date, string time, string patientID, string doctorQualification)
        {
            ScheduleModel note = GetNote(date, time, patientID, doctorQualification);

            if(note == null)
            {
                return "Даного запису не існує";
            }

            return $"Дата і час: {note.AdmissionDate:MM.dd.yyyy} {note.Time} \n\n" +
                           $"Пацієнт: {patientsController.GetPatientInfo(note.Patient.IdentificationCode)}\n" +
                           $"Лікар: {doctorController.GetDoctorInfo(note.Doctor.IdentificationCode)}";
        }

        public string GetNoteDoctorInfo(string date, string time, string patientID, string doctorQualification)
        {
            ScheduleModel note = GetNote(date, time, patientID, doctorQualification);

            if (note == null)
            {
                return "Даного запису не існує";
            }

            return $"Дата і час: {note.AdmissionDate:MM.dd.yyyy} {note.Time} \n\n" +
                           $"Пацієнт: {patientsController.GetPatientInfo(note.Patient.IdentificationCode)}\n";
        }

        private ScheduleModel GetNote(string date, string time, string patientID, string doctorQualification)
        {
            List<ScheduleModel> models = GetNotes(date);
            DateTime dateTime = DateTime.Parse(date);

            if (models == null)
            {
                return null;
            }

            foreach (var model in models)
            {
                if (model.AdmissionDate == dateTime && model.Time  == time && model.Patient.IdentificationCode == patientID && model.Doctor.Qualification == doctorQualification)
                    return model;
            }

            return null;
        }

        public void UpdateNote(ScheduleModel oldNote, ScheduleModel newNote)
        {
            scheduleServices.UpdateNote(oldNote.ToDomain(), newNote.ToDomain());
        }
    }
}

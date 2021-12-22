using System;
using System.Collections.Generic;
using Mapper;
using Models;
using Services;

namespace API.Controllers
{
    public class SearchController
    {
        PatientsService patientsService = new PatientsService();
        PatientsController patientsController = new PatientsController();

        DoctorsService doctorsService = new DoctorsService();
        DoctorsController doctorsController = new DoctorsController();

        ScheduleServices scheduleServices = new ScheduleServices();
        ScheduleController scheduleController = new ScheduleController();

        public string FindPatient(string name, string lastName)
        {
            List<PatientModel> patientModels = patientsService.GetPatients().ToModelList();

            PatientModel findedPatient = patientModels.Find(patient => patient.Name == name || patient.LastName == lastName);

            if(findedPatient == null)
            {
                return "Нічого не знайдено";
            }

            return patientsController.GetPatientInfo(findedPatient.IdentificationCode);
        }

        public string FindDoctor(string name, string lastName)
        {
            List<DoctorModel> doctorModels = doctorsService.GetDoctorsList().ToModelList();

            DoctorModel findedDoctor = doctorModels.Find(doctor => doctor.Name == name || doctor.LastName == lastName);

            if (findedDoctor == null)
            {
                return "Нічого не знайдено";
            }

            return doctorsController.GetDoctorInfo(findedDoctor.IdentificationCode);
        }

        public string GetDoctorScheduleByDate(string date, string id)
        {
            List<ScheduleModel> schedule = scheduleServices.GetNotes(DateTime.Parse(date)).ToModelList();

            List<ScheduleModel> dateSchedule = schedule.FindAll(note => note.AdmissionDate == DateTime.Parse(date) || note.Doctor.IdentificationCode == id);

            if (dateSchedule == null)
            {
                return "\nЗаписів не знайдено\n";
            }

            string res = "";

            foreach(var note in dateSchedule)
            {
                res += scheduleController.GetNoteDoctorInfo(note.AdmissionDate.ToString("dd.MM.yyyy"), note.Time, note.Patient.IdentificationCode, note.Doctor.Qualification);
            }

            if (res == "")
            {
                return "\nЗаписів не знайдено\n";
            }

            return res;
        }
    }
}

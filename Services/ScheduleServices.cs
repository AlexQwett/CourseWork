using System;
using System.Collections.Generic;
using Domain;
using Services.Abstract;
using Data.Reposirories;
using Mapper;

namespace Services
{
    public class ScheduleServices : IScheduleService
    {
        private static ScheduleNoteRepository scheduleRepository = new ScheduleNoteRepository();
        private List<ScheduleNote> _notes = scheduleRepository.GetSchedule().ToDomainList();

        public void AddNote(ScheduleNote note)
        {
            scheduleRepository.AddNote(note.ToEntity());
        }

        public void UpdateNote(ScheduleNote old, ScheduleNote newNote)
        {
            ScheduleNote note = new ScheduleNote
            {
                ID = old.ID,
                AdmissionDate = newNote.AdmissionDate,
                Patient = newNote.Patient,
                Doctor = newNote.Doctor
            };

            scheduleRepository.UpdateSchedule(note.ToEntity());
        }

        public bool DeleteNote(ScheduleNote note)
        {
            try
            {
                _notes = scheduleRepository.GetSchedule().ToDomainList();
                ScheduleNote noteToDelete = _notes.Find(findedNote => findedNote.Patient.IdentificationCode == note.Patient.IdentificationCode &&
                                                                  findedNote.Doctor.IdentificationCode == note.Doctor.IdentificationCode &&
                                                                  findedNote.AdmissionDate == note.AdmissionDate);

                if (noteToDelete == null)
                {
                    throw new Exception("Об'єкта не існує");
                }
                else
                {
                    scheduleRepository.DeleteNote(noteToDelete.ToEntity());
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ScheduleNote> GetNotes(DateTime date)
        {
            try
            {
                _notes = scheduleRepository.GetSchedule().ToDomainList();
                List<ScheduleNote> notes = _notes.FindAll(note => note.AdmissionDate == date);

                if (notes == null)
                    throw new Exception("");
                else
                    return notes;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

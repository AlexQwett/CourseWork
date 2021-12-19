using System;
using System.Collections.Generic;
using Domain;

namespace Services.Abstract
{
    public interface IScheduleService
    {
        void AddNote(ScheduleNote note);
        void UpdateNote(ScheduleNote oldNote, ScheduleNote newNote);
        List<ScheduleNote> GetNotes(DateTime date);
        bool DeleteNote(ScheduleNote note);
    }
}

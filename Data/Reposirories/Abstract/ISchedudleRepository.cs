using System;
using System.Collections.Generic;
using Entities;

namespace Data.Reposirories.Abstract
{
    interface ISchedudleRepository
    {
        void AddNote(ScheduleNoteEntity note);
        void UpdateSchedule(ScheduleNoteEntity note);
        List<ScheduleNoteEntity> GetSchedule();
        void DeleteNote(ScheduleNoteEntity note);
    }
}

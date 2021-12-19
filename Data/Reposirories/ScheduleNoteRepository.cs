using System;
using System.Collections.Generic;
using System.IO;
using Entities;
using Newtonsoft.Json;
using Data.Reposirories.Abstract;

namespace Data.Reposirories
{
    public class ScheduleNoteRepository : ISchedudleRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\CourseworkVar13\Data\DataBases\schedule.json";
        private static string json = File.ReadAllText(path);
        private static List<ScheduleNoteEntity> _notes = new List<ScheduleNoteEntity>();

        public void AddNote(ScheduleNoteEntity note)
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<ScheduleNoteEntity>>(json);

            if (_notes == null)
            {
                _notes = new List<ScheduleNoteEntity>();
                note.ID = 0;
            }
            else
            {
                note.ID = _notes.Count;
            }

            _notes.Add(note);

            File.WriteAllText(path, JsonConvert.SerializeObject(_notes, Formatting.Indented));
        }

        public void DeleteNote(ScheduleNoteEntity note)
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<ScheduleNoteEntity>>(json);

            _notes.RemoveAt(note.ID);

            for (int i = 0; i < _notes.Count; i++)
            {
                if (_notes[i].ID > note.ID)
                {
                    _notes[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_notes, Formatting.Indented));
        }

        public List<ScheduleNoteEntity> GetSchedule()
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<ScheduleNoteEntity>>(json);

            if (_notes == null)
                _notes = new List<ScheduleNoteEntity>();

            return _notes;
        }

        public void UpdateSchedule(ScheduleNoteEntity note)
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<ScheduleNoteEntity>>(json);

            _notes[note.ID] = note;
            File.WriteAllText(path, JsonConvert.SerializeObject(_notes, Formatting.Indented));
        }
    }
}

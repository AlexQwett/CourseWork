using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Reposirories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Reposirories.Tests
{
    [TestClass()]
    public class ScheduleNoteRepositoryTests
    {
        [TestMethod()]
        public void GetScheduleTest()
        {
            //Arrange
            ScheduleNoteRepository scheduleNoteRepository = new ScheduleNoteRepository();
            List<ScheduleNoteEntity> scheduleNoteEntities = new List<ScheduleNoteEntity>();

            //Act 
            scheduleNoteEntities = scheduleNoteRepository.GetSchedule();

            //Assert
            Assert.IsNotNull(scheduleNoteEntities);
        }
    }
}
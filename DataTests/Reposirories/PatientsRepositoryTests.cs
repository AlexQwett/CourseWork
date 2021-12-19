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
    public class PatientsRepositoryTests
    {
        [TestMethod()]
        public void GetPatientsTest()
        {
            //Arrange
            PatientsRepository patientsRepository = new PatientsRepository();
            List<PatientEntity> patientEntities = new List<PatientEntity>();

            //Act
            patientEntities = patientsRepository.GetPatients();

            //Assert
            Assert.IsNotNull(patientEntities);
        }
    }
}
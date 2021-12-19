using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Tests
{
    [TestClass()]
    public class PatientsServiceTests
    {
        [TestMethod()]
        public void GetPatientsTest()
        {
            //Arrange
            PatientsService patientsService = new PatientsService();
            List<Patient> patients = new List<Patient>();

            //Act
            patients = patientsService.GetPatients();

            //Assert
            Assert.IsNotNull(patients);
        }
    }
}
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
    public class DoctorsServiceTests
    {
        [TestMethod()]
        public void GetDoctorsListTest()
        {
            //Arrange
            DoctorsService doctorsService = new DoctorsService();
            List<Doctor> doctors = new List<Doctor>();

            //Act
            doctors = doctorsService.GetDoctorsList();

            //Assert
            Assert.IsNotNull(doctors);
        }
    }
}
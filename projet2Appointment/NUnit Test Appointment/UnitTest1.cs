using NUnit.Framework;
using System.Collections.Generic;
using projet2Appointment;


namespace NUnit_Test_Appointment
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFilter()
        {
            Assert.Pass();
            List<Appointment> testAppointment = new List<Appointment>();
            Appointment appointment = new Appointment
            {
                Importance = 1
            };
            testAppointment.Add(appointment);

            appointment = new Appointment
            {
                Importance = 0
            };
            testAppointment.Add(appointment);

            Criteria criteria = new Criteria();
            criteria.Name = "Importance";
            criteria.Value = 1;

        }
    }
}
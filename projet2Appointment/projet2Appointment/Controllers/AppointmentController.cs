using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace projet2Appointment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private static List<Appointment> myList = new List<Appointment>();

        [HttpGet]
        public List<Appointment> Get()
        {
            myList.Sort((x, y) => DateTime.Compare(x.BeginDate, y.BeginDate));
            int i = 0;
            foreach (Appointment appointment in myList)
            {
                appointment.Id = i;
                i++;
            }
            return myList;
        }

        [HttpPost]
        public Appointment InsertAppointment(Appointment appointment)
        {
                Appointment myAppointment = new Appointment
                {
                    Rdv = appointment.Rdv,
                    BeginDate = appointment.BeginDate,
                    EndDate = appointment.EndDate,
                    Description = appointment.Description
                };

            if (Appointment.dateCheck = true)
            {
                myList.Add(myAppointment);
                return myAppointment;
            }
        }

        public bool dateCheck(DateTime BeginDate, DateTime EndDate)
        {
            bool result;
            int Numresult = DateTime.Compare(BeginDate, EndDate);

            if (Numresult < 1)
                {
                    result = true;
                }

            else
            {
                result = false;
            }
            return result; 

        }


        [HttpDelete]
        public List<Appointment> DeleteAppointment(Appointment appointementToDelete)
        {
            myList.RemoveAt(appointementToDelete.Id);
            return myList;
        }
    }

}


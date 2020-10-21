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
        List<Appointment> myList = new List<Appointment>();

        [HttpGet]
        public List<Appointment> Get()
        {
            


            myList.Add(new Appointment
            {
                Id = 1,
                Rdv = "My first RDV",
                BeginDate = new DateTime(2020, 8, 8, 16, 0, 0),
                EndDate = new DateTime(2020, 8, 8, 16, 15, 0),
                Description = "This is my first rdv",
            });
            myList.Add(new Appointment
            {
                Id = 2,
                Rdv = "My second RDV",
                BeginDate = new DateTime(2020, 12, 8, 16, 0, 0),
                EndDate = new DateTime(2020, 12, 8, 16, 15, 0),
                Description = "This is my second rdv :)",
            });
            
            return myList;
        }

        /*[HttpPost]
        public string InsertAppointment(Appointment appointment)
        {
           Appointment myList. = new Appointment();
            myAppointment.Id = appointment.Id;
            myAppointment.Rdv = appointment.Rdv;
            myAppointment.BeginDate = appointment.BeginDate;
            myAppointment.EndDate = appointment.EndDate;
            myAppointment.Description = appointment.Description;
            return "congrats you add a new rdv";
        }

        }*/
    }
}

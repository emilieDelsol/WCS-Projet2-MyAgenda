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

        [HttpGet]
        public List<Appointment> Get()
        {
            return new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    Rdv = "My first RDV",
                    BeginDate = new DateTime(2020, 8, 8, 16, 0,0),
                    EndDate = new DateTime(2020,8,8,16,15,0),
                    Description = "This is my first rdv",
                },
                new Appointment
                {
                    Id = 2,
                    Rdv = "My second RDV",
                    BeginDate = new DateTime(2020, 12, 8, 16, 0,0),
                    EndDate = new DateTime(2020,12,8,16,15,0),
                    Description="This is my second rdv :)",
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace projet2Appointment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        
        private static List<Appointment> myList = new List<Appointment>();
        public ModifyList modifyList = new ModifyList();

        [HttpGet]
        public List<Appointment> GetAllAppointments()
        {

           return DataAbstractionLayer.SelectAllAppointments();

        }

        [HttpGet("filter/pro")]
        public List<Appointment> GetProAppointments()
        {
            return DataAbstractionLayer.SelectProAppointments();
        }

        [HttpGet("filter/perso")]
        public List<Appointment> GetPersoAppointments()
        {
            return DataAbstractionLayer.SelectPersoAppointments(); 
        }
        [HttpGet("filter/importance")]
        public List<Appointment> GetImportantAppointments()
        {
            return DataAbstractionLayer.SelectImportantAppointments();            
        }

        [HttpGet("filter/importance/pro")]
        [HttpGet("filter/pro/importance")]
        public List<Appointment>GetImportancePro()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.SelectImportantProAppointments();

        }

        [HttpGet("filter/importance/perso")]
        [HttpGet("filter/perso/importance")]
        public List<Appointment> GetImportancePerso()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.SelectImportantPersoAppointments();

        }
        [HttpGet("filter/date")]
        public List<Appointment> GetBetweenDate([FromQuery(Name ="beginDateFilter")] String beginDateFilter, [FromQuery (Name = "endDateFilter")] String endDateFilter)
        {    

            return DataAbstractionLayer.SelectBetweenDate(beginDateFilter,endDateFilter);

        }

        [HttpPost]
        public Appointment PostAppointment(Appointment myUserEntry)
        {   
            return DataAbstractionLayer.InsertAppointment(myUserEntry);   
        }


        [HttpPut]
        public Appointment PutAppointment(Appointment myUserEntry)
        {
            return DataAbstractionLayer.UpdateAppointment(myUserEntry);
        }


       
        [HttpDelete]
        public HttpResponseMessage DeleteMyAppointment(Appointment appointmentToDelete)
        {
            return DataAbstractionLayer.DeleteMyAppointment(appointmentToDelete);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Appointment> SelectAllAppointments()
        {
           return DataAbstractionLayer.SelectAllAppointments();
        }

        [HttpGet("filter/pro")]
        public List<Appointment> SelectProAppointments()
        {
            return DataAbstractionLayer.SelectProAppointments();
        }

        [HttpGet("filter/perso")]
        public List<Appointment> SelectPersoAppointments()
        {
            return DataAbstractionLayer.SelectPersoAppointments(); 
        }

        [HttpGet("filter/importance")]
        public List<Appointment> SelectImportantAppointments()
        {
            return DataAbstractionLayer.SelectImportantAppointments();            
        }

        [HttpGet("filter/importance/pro")]
        [HttpGet("filter/pro/importance")]
        public List<Appointment> SelectImportancePro()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.SelectImportantProAppointments();

        }

        [HttpGet("filter/importance/perso")]
        [HttpGet("filter/perso/importance")]
        public List<Appointment> SelectImportancePerso()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.SelectImportantPersoAppointments();

        }
        [HttpGet("filter/date")]
        public List<Appointment> SelectBetweenDate([FromQuery(Name ="beginDateFilter")] String beginDateFilter, [FromQuery (Name = "endDateFilter")] String endDateFilter)
        {    

            return DataAbstractionLayer.SelectBetweenDate(beginDateFilter,endDateFilter);

        }

        [HttpPost]
        public Appointment PostAppointment(Appointment myUserEntry)
        {   
            return DataAbstractionLayer.PostAppointment(myUserEntry);   
        }


        [HttpPut]
        public Appointment UpdateAppointment(Appointment myUserEntry)
        {
            return DataAbstractionLayer.UpdateAppointment(myUserEntry);
        }


       
        [HttpDelete]
        public List<Appointment> DeleteAppointment(Int32 id)
        {
            if (myList.Count > 0)
            {
                myList.RemoveAt(id);
            }
            return myList;
        }
    }
}


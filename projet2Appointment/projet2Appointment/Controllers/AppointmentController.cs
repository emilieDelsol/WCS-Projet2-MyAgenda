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
        public List<Appointment> GetList()
        {
           return DataAbstractionLayer.GetAllAppointments();
        }

        [HttpGet("filter/pro")]
        public List<Appointment> GetFilterPro()
        {
            return DataAbstractionLayer.GetProAppointments();
        }

        [HttpGet("filter/perso")]
        public List<Appointment> GetFilterPerso()
        {
            return DataAbstractionLayer.GetPersoAppointments(); 
        }

        [HttpGet("filter/importance")]
        public List<Appointment> GetFilterImportance()
        {
            return DataAbstractionLayer.GetImportantAppointments();            
        }

        [HttpGet("filter/importance/pro")]
        [HttpGet("filter/pro/importance")]
        public List<Appointment> GetFilterImportancePro()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.GetImportantProAppointments();

        }

        [HttpGet("filter/importance/perso")]
        [HttpGet("filter/perso/importance")]
        public List<Appointment> GetFilterImportancePerso()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.GetImportantPersoAppointments();

        }
        [HttpGet("filter/date")]
        public List<Appointment> GetFilterBetweenDate([FromQuery(Name ="beginDateFilter")] String beginDateFilter, [FromQuery (Name = "endDateFilter")] String endDateFilter)
        {    

            return DataAbstractionLayer.GetBetweenDate(beginDateFilter,endDateFilter);

        }

        [HttpPost]
        public Appointment InsertMyAppointment(Appointment myUserEntry)
        {   
            return DataAbstractionLayer.InsertAppointments(myUserEntry);   
        }


        [HttpPut]
        public Appointment PutAppointment(Appointment myUserEntry)
        {
            return DataAbstractionLayer.PutAppointment(myUserEntry);
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


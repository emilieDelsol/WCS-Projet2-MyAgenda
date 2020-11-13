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
            List<Appointment> listFilterPro = new List<Appointment>();
            return DataAbstractionLayer.SelectProAppointments();
        }

        [HttpGet("filter/perso")]
        public List<Appointment> GetPersoAppointments()
        {

            List<Appointment> listFilterPerso = new List<Appointment>();
            return DataAbstractionLayer.SelectPersoAppointments(); 
        }
        [HttpGet("filter/importance")]
        public List<Appointment> GetImportantAppointments()
        {
            List<Appointment> listFilterImportance = new List<Appointment>();                      
            return DataAbstractionLayer.SelectImportantAppointments();            
        }

        [HttpGet("filter/importance/pro")]
        [HttpGet("filter/pro/importance")]

        public List<Appointment> GetFilterImportancePro()
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

        [HttpGet("searchByWord")]
        public List<Appointment> GetByWord([FromQuery(Name = "wordSearch")] String wordSearch)
        {    
            return DataAbstractionLayer.SearchByWord(wordSearch);
        }

        [HttpGet("filter/importance/date")]
     
        public List<Appointment> GetFilterBetweenDateImportance([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDateImportance(beginDateFilter, endDateFilter);
        }


        [HttpGet("filter/pro/date")]
        
        public List<Appointment> GetFilterBetweenDatePro([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDatePro(beginDateFilter, endDateFilter);
        }

        [HttpGet("filter/perso/date")]

        public List<Appointment> GetFilterBetweenDatePerso([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDatePerso(beginDateFilter, endDateFilter);
        }

        [HttpGet("filter/perso/importance/date")]
        [HttpGet("filter/importance/perso/date")]

        public List<Appointment> GetFilterBetweenDatePersoImportance([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDatePersoImportance(beginDateFilter, endDateFilter);
        }


        [HttpGet("filter/pro/importance/date")]
        [HttpGet("filter/importance/pro/date")]

        public List<Appointment> GetFilterBetweenDateProImportance([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {
            return DataAbstractionLayer.SelectBetweenDateProImportance(beginDateFilter, endDateFilter);
        }

        [HttpPost]

        public Appointment PostMyAppointment(Appointment myUserEntry)
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


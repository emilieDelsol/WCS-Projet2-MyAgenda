using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public List<Appointment> GetImportantAppointments([FromQuery(Name = "importanceFilter")] String importanceFilter)
        {

            return DataAbstractionLayer.SelectImportantAppointments(importanceFilter);            

        }

        [HttpGet("filter/pro/importance")]

        public List<Appointment>GetImportancePro([FromQuery(Name = "importanceFilter")] String importanceFilter)


        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.SelectImportantProAppointments(importanceFilter);

        }

        [HttpGet("filter/importance/perso")]
        [HttpGet("filter/perso/importance")]
        public List<Appointment> GetImportancePerso([FromQuery(Name = "importanceFilter")] String importanceFilter)
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();

            return DataAbstractionLayer.SelectImportantPersoAppointments(importanceFilter);


        }

        [HttpGet("filter/date")]
        public List<Appointment> GetBetweenDate([FromQuery(Name ="beginDateFilter")] String beginDateFilter, [FromQuery (Name = "endDateFilter")] String endDateFilter)
        {    
            return DataAbstractionLayer.SelectBetweenDate(beginDateFilter,endDateFilter);
        }

        [HttpGet("searchByWord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByWord([FromQuery(Name = "wordSearch")] String wordSearch)
        {
            if ((wordSearch)==null)
            {
                return NotFound();
            }
           return Ok( DataAbstractionLayer.SearchByWord(wordSearch));
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


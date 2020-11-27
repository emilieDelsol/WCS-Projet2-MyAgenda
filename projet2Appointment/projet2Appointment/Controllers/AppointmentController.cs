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
        [HttpGet]
        public List<Appointment> GetAllAppointments(bool pro=false)
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
        public List<Appointment> GetImportantAppointments([FromQuery(Name = "importanceFilter")] String importanceFilter)
        {

            return DataAbstractionLayer.SelectImportantAppointments(importanceFilter);            

        }

        [HttpGet("filter/pro/importance")]

        public List<Appointment>GetImportancePro([FromQuery(Name = "importanceFilter")] String importanceFilter)


        {
            return DataAbstractionLayer.SelectImportantProAppointments(importanceFilter);

        }

        [HttpGet("filter/importance/perso")]
        [HttpGet("filter/perso/importance")]
        public List<Appointment> GetImportancePerso([FromQuery(Name = "importanceFilter")] String importanceFilter)
        {
            return DataAbstractionLayer.SelectImportantPersoAppointments(importanceFilter);
        }

        [HttpGet("filter/date")]
        public List<Appointment> GetBetweenDate([FromQuery(Name ="beginDateFilter")] String beginDateFilter, [FromQuery (Name = "endDateFilter")] String endDateFilter)
        {    
            return DataAbstractionLayer.SelectBetweenDate(beginDateFilter,endDateFilter);
        }

        [HttpGet("searchByWord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByWord([FromQuery(Name = "wordSearch")] String wordSearch)
        {
            if ((wordSearch)==null)
            {
                return BadRequest();
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult  PostMyAppointment(Appointment myUserEntry)
        {   
            if ( DataAbstractionLayer.InsertAppointment(myUserEntry))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

       
        [HttpPut]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutAppointment(Appointment myUserEntry)
        {
            if (DataAbstractionLayer.UpdateAppointment(myUserEntry))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


       
        [HttpDelete]
        public HttpResponseMessage DeleteMyAppointment(Appointment appointmentToDelete)
        {
            return DataAbstractionLayer.DeleteMyAppointment(appointmentToDelete);
        }
    }
}


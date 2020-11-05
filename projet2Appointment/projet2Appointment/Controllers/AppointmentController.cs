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
            modifyList.SortByBeginDate(myList);
            modifyList.ChangeID(myList);
            

            return DataAbstractionLayer.GetAllAppointments();

        }

        [HttpGet("filter/pro")]
        public List<Appointment> SelectFilterPro()
        {
            List<Appointment> listFilterPro = new List<Appointment>();
            return DataAbstractionLayer.SelectProAppointments();
        }

        [HttpGet("filter/perso")]
        public List<Appointment> SelectFilterPerso()
        {
            List<Appointment> listFilterPerso = new List<Appointment>();

            return DataAbstractionLayer.SelectPersoAppointments(); 
        }

        [HttpGet("filter/importance")]
        public List<Appointment> SelectFilterImportance()
        {
            List<Appointment> listFilterImportance = new List<Appointment>();                      
            return DataAbstractionLayer.SelectImportantAppointments();            
        }

        [HttpGet("filter/importance/pro")]
        [HttpGet("filter/pro/importance")]
        public List<Appointment> SelectFilterImportancePro()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.SelectImportantProAppointments();
        }

        [HttpGet("filter/importance/perso")]
        [HttpGet("filter/perso/importance")]
        public List<Appointment> SelectFilterImportancePerso()
        {
            List<Appointment> listFilterImportancePro = new List<Appointment>();
            return DataAbstractionLayer.SelectImportantPersoAppointments();
        }

        [HttpGet("filter/date")]
        public List<Appointment> SelectFilterBetweenDate([FromQuery(Name ="beginDateFilter")] String beginDateFilter, [FromQuery (Name = "endDateFilter")] String endDateFilter)
        {    

            return DataAbstractionLayer.SelectBetweenDate(beginDateFilter,endDateFilter);

        }

        [HttpGet("filter/importance/date")]
     
        public List<Appointment> SelectFilterBetweenDateImportance([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDateImportance(beginDateFilter, endDateFilter);
        }


        [HttpGet("filter/pro/date")]
        
        public List<Appointment> SelectFilterBetweenDatePro([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDatePro(beginDateFilter, endDateFilter);
        }

        [HttpGet("filter/perso/date")]

        public List<Appointment> SelectFilterBetweenDatePerso([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDatePerso(beginDateFilter, endDateFilter);
        }

        [HttpGet("filter/perso/importance/date")]
        [HttpGet("filter/importance/perso/date")]

        public List<Appointment> SelectFilterBetweenDatePersoImportance([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDatePersoImportance(beginDateFilter, endDateFilter);
        }


        [HttpGet("filter/pro/importance/date")]
        [HttpGet("filter/importance/pro/date")]

        public List<Appointment> SelectFilterBetweenDateProImportance([FromQuery(Name = "beginDateFilter")] String beginDateFilter, [FromQuery(Name = "endDateFilter")] String endDateFilter)
        {

            return DataAbstractionLayer.SelectBetweenDateProImportance(beginDateFilter, endDateFilter);
        }

        [HttpPost]
        public Appointment InsertMyAppointment(Appointment myUserEntry)
        {   
            return DataAbstractionLayer.InsertAppointments(myUserEntry);   
        }


        [HttpPut]
        public Appointment ModifyAppointment(Appointment myUserEntry)
        {
            
            return DataAbstractionLayer.PutAppointments(myUserEntry);
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


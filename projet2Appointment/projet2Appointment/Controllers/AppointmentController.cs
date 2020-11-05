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
        public List<Appointment> GetFilterPro()
        {
            List<Appointment> listFilterPro = new List<Appointment>();
            return DataAbstractionLayer.GetProAppointments();
        }

        [HttpGet("filter/perso")]
        public List<Appointment> GetFilterPerso()
        {
            List<Appointment> listFilterPerso = new List<Appointment>();

            return DataAbstractionLayer.GetPersoAppointments(); 
        }

        [HttpGet("filter/importance")]
        public List<Appointment> GetFilterImportance()
        {
            List<Appointment> listFilterImportance = new List<Appointment>();                      
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


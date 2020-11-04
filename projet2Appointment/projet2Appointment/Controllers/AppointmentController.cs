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
            List<Appointment> listFilter = new List<Appointment>();



            modifyList.filterByType(listFilter, myList, "pro");
            

            return listFilter;
        }

        [HttpGet("filter/perso")]
        public List<Appointment> GetFilterPerso()
        {

            List<Appointment> listFilterPerso = new List<Appointment>();


           
            return DataAbstractionLayer.GetPersoAppointments();


            
        }

        [HttpGet("filter/date")]
        public List<Appointment> GetFilterBetweenDate([FromQuery(Name ="beginDateFilter")] String beginDateFilter, [FromQuery (Name = "endDateFilter")] String endDateFilter)
        {    

            return DataAbstractionLayer.GetBetweenDate(beginDateFilter,endDateFilter);

        }

        [HttpPost]
        public Appointment PostMyAppointment(Appointment myUserEntry)
        {   
            return DataAbstractionLayer.PostAppointments(myUserEntry);   
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


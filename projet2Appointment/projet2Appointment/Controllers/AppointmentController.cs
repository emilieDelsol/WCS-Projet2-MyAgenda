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
            myList.Sort((x, y) => DateTime.Compare(x.BeginDate, y.BeginDate));
            int i = 0;
            foreach (Appointment appointment in myList)
            {
                appointment.Id = i;
                i++;
            }
            return DataAbstractionLayer.GetAllAppointments();
        }

        [HttpGet("filter/pro")]
        public List<Appointment> GetFilterPro()
        {
            List<Appointment> listFilter = new List<Appointment>();

            modifyList.SortByType(listFilter, myList, "pro");
            modifyList.SortByBeginDate(listFilter);
            modifyList.ChangeID(listFilter);
            return listFilter;
        }

        [HttpGet("filter/perso")]
        public List<Appointment> GetFilterPerso()
        {

            List<Appointment> listFilterPerso = new List<Appointment>();

            modifyList.SortByType(listFilterPerso, myList, "perso");
            modifyList.SortByBeginDate(listFilterPerso);
            modifyList.ChangeID(listFilterPerso);
            return listFilterPerso;
        }

        [HttpPost]
        public Appointment InsertAppointment(Appointment appointment)
        {   
            myList.Add(appointment);
            return appointment;   
        }


        [HttpPut]
        public List<Appointment> ModifyAppointment(Appointment newAppointment)
        {
            myList[newAppointment.Id] = newAppointment;
            return myList;
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


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
            return myList;
        }

        [HttpGet("filter/pro")]

        public List<Appointment> GetFilterPro()
        {
            
            List<Appointment> listFilter = new List<Appointment>();

            modifyList.filterByType(listFilter, myList, "pro");
            modifyList.SortByBeginDate(listFilter);
            modifyList.ChangeID(listFilter);
            return listFilter;


        }

        [HttpGet("filter/perso")]

        public List<Appointment> GetFilterPerso()
        {

            List<Appointment> listFilterPerso = new List<Appointment>();

            modifyList.filterByType(listFilterPerso, myList, "perso");
            modifyList.SortByBeginDate(listFilterPerso);
            modifyList.ChangeID(listFilterPerso);
            return listFilterPerso;
           
        }

        [HttpGet("filter/date")]
        public List<Appointment> GetFilterByDate(String dateAsString)
        {
            // "00/00/00 00:00:00" https://www.c-sharpcorner.com/UploadFile/mahesh/working-with-datetime-using-C-Sharp/
            /*DateTime dateFromString =
                DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine(dateFromString.ToString());*/
            List<Appointment> listFilterByDate = new List<Appointment>();
            modifyList.filterBetweenDate(listFilterByDate, myList, dateAsString);

            return listFilterByDate;
        }

        [HttpPost]
        public Appointment InsertAppointment(Appointment appointment)
        {
            Appointment myAppointment = new Appointment
            {
                Rdv = appointment.Rdv,
                BeginDate = appointment.BeginDate,
                EndDate = appointment.EndDate,
                Description = appointment.Description,
                Pro = appointment.Pro,
                Perso=appointment.Perso

                
            };

            
            myList.Add(myAppointment);
            return myAppointment;
            
        }

       


        [HttpDelete]
        public List<Appointment> DeleteAppointment(Appointment appointementToDelete)
        {
            myList.RemoveAt(appointementToDelete.Id);
            return myList;
        }
    }

}


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

            modifyList.SortByType(listFilter, myList, "pro");
            modifyList.SortByBeginDate(listFilter);
            modifyList.ChangeID(listFilter);
            return listFilter;


        }

        [HttpGet("filter/perso")]

        public List<Appointment> GetFilterPerso()
        {

            List<Appointment> listFilterPerso = new List<Appointment>();

            modifyList.SortByType(listFilterPerso, myList, "pro");
            modifyList.SortByBeginDate(listFilterPerso);
            modifyList.ChangeID(listFilterPerso);
            return listFilterPerso;
            


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
                Perso=appointment.Perso,
                Address = appointment.Address,
                Contact = appointment.Contact,
                Email = appointment.Email,
                Phone = appointment.Phone,
                Importance = appointment.Importance,
                Recurrence = appointment.Recurrence,
                Reminder = appointment.Reminder

            };

            
            myList.Add(myAppointment);
            return myAppointment;
            
        }


        [HttpPut]
        public List<Appointment> ModifyAppointment(ReplaceAppointment modified)
        {
            ReplaceAppointment modifyAppointment = new ReplaceAppointment
            {
                IdReplace = modified.IdReplace,
                RdvReplace = modified.RdvReplace,
                BeginDateReplace = modified.BeginDateReplace,
                EndDateReplace = modified.EndDateReplace,
                DescriptionReplace = modified.DescriptionReplace,
                AddressReplace = modified.AddressReplace,
                ContactReplace = modified.ContactReplace,
                EmailReplace = modified.EmailReplace,
                PhoneReplace = modified.PhoneReplace,
                ImportanceReplace = modified.ImportanceReplace,
                RecurrenceReplace = modified.RecurrenceReplace,
                ReminderReplace = modified.ReminderReplace,
            };

            myList[modifyAppointment.IdReplace].Rdv = modifyAppointment.RdvReplace;
            myList[modifyAppointment.IdReplace].BeginDate = modifyAppointment.BeginDateReplace;
            myList[modifyAppointment.IdReplace].EndDate = modifyAppointment.EndDateReplace;
            myList[modifyAppointment.IdReplace].Description = modifyAppointment.DescriptionReplace;
            myList[modifyAppointment.IdReplace].Address = modifyAppointment.AddressReplace;
            myList[modifyAppointment.IdReplace].Contact = modifyAppointment.ContactReplace;
            myList[modifyAppointment.IdReplace].Email = modifyAppointment.EmailReplace;
            myList[modifyAppointment.IdReplace].Phone = modifyAppointment.PhoneReplace;
            myList[modifyAppointment.IdReplace].Importance = modifyAppointment.ImportanceReplace;
            myList[modifyAppointment.IdReplace].Recurrence = modifyAppointment.RecurrenceReplace;
            myList[modifyAppointment.IdReplace].Reminder = modifyAppointment.ReminderReplace;
            return myList;
        }

       

        [HttpDelete]
        public List<Appointment> DeleteAppointment(Appointment appointementToDelete)
        {
            myList.RemoveAt(appointementToDelete.Id);
            return myList;
        }
    }

}


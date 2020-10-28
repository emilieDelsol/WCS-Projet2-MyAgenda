using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet2Appointment
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Rdv { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Importance { get; set; }

        public bool Recurrence { get; set; }

        public bool Reminder { get; set; }

        public string InsertAppointment { get; set; }

        public List<Appointment> DeleteAppointment { get; set; }

        public bool Pro { get; set; }

        public bool Perso { get; set; }

        
    }
    public class ModifyList
    {
        public void ChangeID(List<Appointment> list)
        {
            int i = 0;
            foreach (Appointment appointment in list)
            {
                appointment.Id = i;
                i++;
            }
            
        }
        

        public void SortByBeginDate(List<Appointment> list)
        {
            list.Sort((x, y) => DateTime.Compare(x.BeginDate, y.BeginDate));
        }

        public void SortByType(List<Appointment> list, List<Appointment> mylist, string type)
        {

            if (type == "pro")
            {
                foreach (Appointment value in mylist)
                {
                    if (value.Pro == true)
                    {
                        list.Add(value);
                    }

                }
            }
            else if (type == "perso")
            {
                foreach (Appointment value in mylist)
                {
                    if (value.Perso == true)
                    {
                        list.Add(value);
                    }

                }
            }
            
        }

    }

    public class ReplaceAppointment
    {
        public int IdReplace { get; set; }

        public string RdvReplace { get; set; }

        public DateTime BeginDateReplace { get; set; }

        public DateTime EndDateReplace { get; set; }

        public string DescriptionReplace { get; set; }

        public string AddressReplace { get; set; }

        public string ContactReplace { get; set; }

        public string EmailReplace { get; set; }

        public string PhoneReplace { get; set; }

        public int ImportanceReplace { get; set; }

        public bool RecurrenceReplace { get; set; }

        public bool ReminderReplace { get; set; }

    }

}

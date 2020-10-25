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

}

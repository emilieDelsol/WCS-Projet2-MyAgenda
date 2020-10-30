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

        public void filterByType(List<Appointment> list, List<Appointment> mylist, string type)
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
        public void filterByDate(List<Appointment> list, List<Appointment> myList, DateTime beginFilter)
        {
            foreach(Appointment appointment in myList)
            {
                if(appointment.BeginDate>=beginFilter) {//a résoudre changement de type 
                    /*DateTime dateFromString =
                        DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
                        Console.WriteLine(dateFromString.ToString());

                     "00/00/00 00:00:00" https://www.c-sharpcorner.com/UploadFile/mahesh/working-with-datetime-using-C-Sharp/
                    {
                    see this doc: 
                    https://stackoverflow.com/questions/41577376/how-to-read-values-from-the-querystring-with-asp-net-core
                    */
                    list.Add(appointment);
                }
            }
        }
    }

}

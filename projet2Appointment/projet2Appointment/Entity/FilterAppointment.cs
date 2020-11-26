using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet2Appointment.Entity
{
    public class FilterAppointment
    {
      
        public List<Appointment> Filter(IEnumerable<Appointment>appointments, List<Criteria>criterias)
        {
            criterias = new List<Criteria>() { new Criteria { Name = "Importance", Value = 0 } };

            appointments = DataAbstractionLayer.SelectAllAppointments();

            List<Appointment> appointmentFilter = new List<Appointment>();

            foreach (Appointment a in appointments)

                foreach (Criteria c in criterias)

            //si un rdv satisfait les criteres ajoute un rdv à la liste
                    if ( a.Importance == c.Value)
                    {
                        appointmentFilter.Add(a);
                    }

            return appointmentFilter;

        }
    }
}

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

        public int Frequence { get; set; }

        public int NumberOfRecurrence { get; set; }
        
        public bool Pro { get; set; }
    }
   

}

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

    }

    public class ReplaceAppointment
    {
        public int IdReplace { get; set; }

        public string RdvReplace { get; set; }

        public DateTime BeginDateReplace { get; set; }

        public DateTime EndDateReplace { get; set; }

        public string DescriptionReplace { get; set; }
    }

}

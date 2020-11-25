using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet2Appointment
{
    public class AppointmentRepository
    {
        public static IEnumerable<Appointment> SelectAppointments(IEnumerable<Criteria> criterias)
        {
            IList<Appointment> appointments = new List<Appointment>();
            String query = @"SELECT IdAppointment, Rdv, BeginDate, EndDate,
                                 ISNULL(AppointmentDescription, ''),
                                 ISNULL(AppointmentAddress, ''),
                                 ISNULL(Contact, ''),
                                 ISNULL(Email, ''),
                                 ISNULL(Phone, ''),
                                 ISNULL(Importance, 0),
                                 ISNULL(recurrence, 0),
                                 ISNULL(Frequence, 0),
                                 ISNULL(NumberOfRecurrence, 0),
                                 ISNULL(Pro, 0) ";

            while (reader.Read)
            {
                Appointment appointment = new Appointment
                {
                    Id = reader.GetInt32(0),
                    Rdv = reader.GetString(1),
                    BeginDate = reader.GetDateTime(2),
                    EndDate = reader.GetDateTime(3),
                    Description = reader.GetString(4),
                    Address = reader.GetString(5),
                    Contact = reader.GetString(6),
                    Email = reader.GetString(7),
                    Phone = reader.GetString(8),
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Pro = reader.GetBoolean(13),
                };
            }

            query += " FROM Appointment";

            return appointments.OrderBy((a) => a.BeginDate);
        }
    }
}

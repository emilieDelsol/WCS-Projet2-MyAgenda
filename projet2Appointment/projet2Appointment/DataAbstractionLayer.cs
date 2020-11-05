using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace projet2Appointment
{
    public static class DataAbstractionLayer
    {
        private static SqlConnection _connection = new SqlConnection();

        public static void Open(SqlConnectionStringBuilder stringBuilder)
        {
            _connection.ConnectionString = stringBuilder.ConnectionString;
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public static SqlConnection GetConnection()
        {
            return _connection;
        }

        public static List<Appointment> GetAllAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment ORDER BY BeginDate";
            SqlDataReader reader = command.ExecuteReader();
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
            {
                Appointment appointment = new Appointment 
                { 
                    Id = reader.GetInt32(0), 
                    Rdv = reader.GetString(1), 
                    BeginDate = reader.GetDateTime(2), 
                    EndDate = reader.GetDateTime(3), 
                    Description = reader.GetString(4),
                    Address=reader.GetString(5), 
                    Contact = reader.GetString(6),
                    Email = reader.GetString(7),
                    Phone = reader.GetString(8),
                    Importance = reader.GetBoolean(9),
                    Recurrence = reader.GetBoolean(10),
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                }; //On peux auusi appeler les elements avec reader[0] a la place de reader.GetInt32(0)
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> GetProAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (Pro=1)";
            SqlDataReader reader = command.ExecuteReader();
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
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
                    Importance = reader.GetBoolean(9),
                    Recurrence = reader.GetBoolean(10),
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        public static List<Appointment> GetPersoAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (Perso=1)";
            SqlDataReader reader  = command.ExecuteReader();
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
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
                    Importance = reader.GetBoolean(9),
                    Recurrence = reader.GetBoolean(10),
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

         public static List<Appointment> GetImportantAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (Importance=1)";
            SqlDataReader reader  = command.ExecuteReader();
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
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
                    Importance = reader.GetBoolean(9),
                    Recurrence = reader.GetBoolean(10),
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        public static List<Appointment> GetBetweenDate(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter)";
            command.Parameters.AddWithValue("@beginDateFilter", beginDateFilter);
            command.Parameters.AddWithValue("@endDateFilter", endDateFilter);
            SqlDataReader reader = command.ExecuteReader();
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
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
                    Importance = reader.GetBoolean(9),
                    Recurrence = reader.GetBoolean(10),
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static Appointment InsertAppointment(Appointment userEntry)
        {
            SqlCommand command = _connection.CreateCommand();
            /*            command.CommandText = "INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, Recurence, Reminder, Pro, Perso) VALUES ('Réunion parent-prof', '2020-11-10T17:00:00', '2020-11-10T18:00:00', 'Réunion pour le petit Adrien', 'Ecole des cancres 31140 Montberon', 'Madame la CPE','','051234567', '2', 'false', 'true', 'false', 'false');";
            */
            command.CommandText = "INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, Recurence, Reminder, Pro, Perso) " +
                "VALUES (@rdv,@beginDate, @endDate, @description, @address, @contact,@email,@phone,@importance,@recurence,@reminder,@pro,@perso);";
            command.Parameters.AddWithValue("@rdv", userEntry.Rdv);
            command.Parameters.AddWithValue("@beginDate", userEntry.BeginDate);
            command.Parameters.AddWithValue("@endDate", userEntry.EndDate);
            command.Parameters.AddWithValue("@description", userEntry.Description);
            command.Parameters.AddWithValue("@address", userEntry.Address);
            command.Parameters.AddWithValue("@contact", userEntry.Contact);
            command.Parameters.AddWithValue("@email", userEntry.Email);
            command.Parameters.AddWithValue("@phone", userEntry.Phone);
            command.Parameters.AddWithValue("@importance", userEntry.Importance);
            command.Parameters.AddWithValue("@recurence", userEntry.Recurrence);
            command.Parameters.AddWithValue("@reminder", userEntry.Reminder);
            command.Parameters.AddWithValue("@pro", userEntry.Pro);
            command.Parameters.AddWithValue("@perso", userEntry.Perso);
            SqlDataReader reader = command.ExecuteReader();
            
            
            reader.Close();
            return userEntry;
        }

         public static Appointment ModifyAppointment(Appointment userEntry)
        {
            SqlCommand command = _connection.CreateCommand();
            
            command.CommandText = "UPDATE Appointment SET Rdv = @rdv, BeginDate = @beginDate, EndDate = @endDate, AppointmentDescription = @description, AppointmentAddress = @address, Contact = @contact, Email = @email, Phone = @phone, Importance = @importance, Recurence = @recurence, Reminder = @reminder, Pro = @pro, Perso = @perso WHERE IdAppointment = @idUserEntry";

            command.Parameters.AddWithValue("@idUserEntry", userEntry.Id);
            command.Parameters.AddWithValue("@rdv", userEntry.Rdv);
            command.Parameters.AddWithValue("@beginDate", userEntry.BeginDate);
            command.Parameters.AddWithValue("@endDate", userEntry.EndDate);
            command.Parameters.AddWithValue("@description", userEntry.Description);
            command.Parameters.AddWithValue("@address", userEntry.Address);
            command.Parameters.AddWithValue("@contact", userEntry.Contact);
            command.Parameters.AddWithValue("@email", userEntry.Email);
            command.Parameters.AddWithValue("@phone", userEntry.Phone);
            command.Parameters.AddWithValue("@importance", userEntry.Importance);
            command.Parameters.AddWithValue("@recurence", userEntry.Recurrence);
            command.Parameters.AddWithValue("@reminder", userEntry.Reminder);
            command.Parameters.AddWithValue("@pro", userEntry.Pro);
            command.Parameters.AddWithValue("@perso", userEntry.Perso);
            SqlDataReader reader = command.ExecuteReader();

            reader.Close();
            return userEntry;

        }

        public static void Close()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
      
    }
}

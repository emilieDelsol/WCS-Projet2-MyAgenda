using Microsoft.AspNetCore.Mvc.ViewFeatures;
using projet2Appointment.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

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

        public static List<Appointment> SelectAllAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv,BeginDate,EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(Recurence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Reminder, 0)," +
                                "ISNULL(Pro, 0)," +
                                "ISNULL(Perso, 0)" +
                                "FROM Appointment " +
                                "ORDER BY BeginDate";
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder=reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                }; //On peux auusi appeler les elements avec reader[0] a la place de reader.GetInt32(0)

                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectProAppointments()
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        public static List<Appointment> SelectPersoAppointments()
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

         public static List<Appointment> SelectImportantAppointments(String importanceFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (Importance=@importanceFilter)";
            command.Parameters.AddWithValue("@importanceFilter", importanceFilter);

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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectImportantProAppointments(String importanceFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (Importance=@importanceFilter AND Pro=1)";
            command.Parameters.AddWithValue("@importanceFilter", importanceFilter);


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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectImportantPersoAppointments(String importanceFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (Importance=@importanceFilter AND Perso=1)";
            command.Parameters.AddWithValue("@importanceFilter", importanceFilter);

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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        public static List<Appointment> SelectBetweenDate(String beginDateFilter, String endDateFilter)
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }


        public static List<Appointment> SelectBetweenDateImportance(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT * FROM Appointment WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Importance = 1)";
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectBetweenDatePro(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Pro = 1)";
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        public static List<Appointment> SelectBetweenDatePerso(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Perso = 1)";
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectBetweenDatePersoImportance(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Perso = 1 AND Importance = 1)";
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectBetweenDateProImportance(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Pro = 1 AND Importance = 1)";
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Reminder = reader.GetBoolean(13),
                    Pro = reader.GetBoolean(14),
                    Perso = reader.GetBoolean(15)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        
        public static Appointment InsertAppointment(Appointment userEntry)
        {
            SqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, Recurence, Reminder, Pro, Perso) " +
                "VALUES (@rdv,@beginDate, @endDate, @description, @address, @contact,@email,@phone,@importance,@recurence,@reminder,@pro,@perso);";
           
            command.Parameters.AddWithValue("@rdv", userEntry.Rdv);
            command.Parameters.AddWithValue("@beginDate", userEntry.BeginDate);
            command.Parameters.AddWithValue("@endDate", userEntry.EndDate);
            command.Parameters.AddWithNullValue("@description", userEntry.Description);
            command.Parameters.AddWithNullValue("@address", userEntry.Address);
            command.Parameters.AddWithNullValue("@contact", userEntry.Contact);
            command.Parameters.AddWithNullValue("@email", userEntry.Email);
            command.Parameters.AddWithNullValue("@phone", userEntry.Phone);
            command.Parameters.AddWithNullValue("@importance", userEntry.Importance);
            command.Parameters.AddWithNullValue("@recurence", userEntry.Recurrence);
            command.Parameters.AddWithNullValue("@frequence", userEntry.Frequence);
            command.Parameters.AddWithNullValue("@numberOfRecurrence", userEntry.NumberOfRecurrence);
            command.Parameters.AddWithDefaultValue("@reminder", userEntry.Reminder, false);
            command.Parameters.AddWithDefaultValue("@pro", userEntry.Pro, false);
            command.Parameters.AddWithDefaultValue("@perso", userEntry.Perso, false);

            command.CommandText = " DECLARE @r INT SET @r = 0 WHILE(@r <= @numberOfRecurrence) BEGIN INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, Recurence, Frequence, NumberOfRecurrence, Reminder, Pro, Perso) " +
                            "VALUES (@rdv,@beginDate+@r, @endDate+@r, @description, @address, @contact,@email,@phone,@importance,@recurence,@frequence, @numberOfRecurrence, @reminder,@pro,@perso) SET @r = @r + 1 END ;";
            command.ExecuteNonQuery();
            
            return userEntry;
        }

         public static bool UpdateAppointment(Appointment userEntry)
         {
            SqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE Appointment SET ";

            if (userEntry.Rdv != null)
            {
                command.CommandText += "Rdv=@rdv";
                command.Parameters.AddWithValue("@rdv", userEntry.Rdv);
            }

            command.CommandText += " WHERE idAppointment = @idUserEntry";
            command.Parameters.AddWithValue("@idUserEntry", userEntry.Id);
            Int32 affectedRowsCount = command.ExecuteNonQuery();
            if (affectedRowsCount < 1)
            {
                return false;
            }
            return true;
        }


        public static List<Appointment> SearchByWord(String wordSearch)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv,BeginDate,EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(Recurence, 0)," +
                                "ISNULL(Reminder, 0)," +
                                "ISNULL(Pro, 0)," +
                                "ISNULL(Perso, 0)" +
                                "FROM Appointment "+
                                "WHERE Rdv LIKE '%'+@wordSearch+'%'" +
                                "OR AppointmentDescription LIKE '%'+@wordSearch+'%' " +
                                "OR AppointmentAddress LIKE '%' + @wordSearch + '%' " +
                                "OR Contact LIKE '%' + @wordSearch + '%'" +
                                "OR Email LIKE '%' + @wordSearch + '%'" +
                                "ORDER BY BeginDate";

            command.Parameters.AddWithValue("@wordSearch", ((object)wordSearch) ?? DBNull.Value);

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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                };
                appointments.Add(appointment);
            }
            reader.Close();
            
            return appointments;
        }
        

        public static HttpResponseMessage DeleteMyAppointment(Appointment appointmentToDelete)
        {
            SqlCommand command = _connection.CreateCommand();

            Appointment appointment = new Appointment();
           
            appointment.Id = appointmentToDelete.Id;
            
            command.CommandText = "DELETE Appointment WHERE IdAppointment = @userEntryIdTodelete";

            command.Parameters.AddWithValue("@userEntryIdTodelete", appointment.Id);
           
            command.ExecuteNonQuery();
            return new HttpResponseMessage( HttpStatusCode.Accepted );

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


/*((object)userEntry.Description = ) ? userEntry.Description : command.CommandText = "SELECT Appointmentdescription WHERE IdAppointment = @idUserEntry;";*/
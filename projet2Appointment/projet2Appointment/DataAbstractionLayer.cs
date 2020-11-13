using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                }; //On peux aussi appeler les elements avec reader[0] a la place de reader.GetInt32(0)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
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

            command.CommandText = "INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, Recurence, Reminder, Pro, Perso) " +
                "VALUES (@rdv,@beginDate, @endDate, @description, @address, @contact,@email,@phone,@importance,@recurence,@reminder,@pro,@perso);";


           
            command.Parameters.AddWithValue("@rdv",userEntry.Rdv);
            command.Parameters.AddWithValue("@beginDate", userEntry.BeginDate);
            command.Parameters.AddWithValue("@endDate", userEntry.EndDate);
            command.Parameters.AddWithValue("@description",((object)userEntry.Description) ?? DBNull.Value);
            command.Parameters.AddWithValue("@address", ((object)userEntry.Address) ?? DBNull.Value);
            command.Parameters.AddWithValue("@contact", ((object)userEntry.Contact) ?? DBNull.Value);
            command.Parameters.AddWithValue("@email", ((object)userEntry.Email) ?? DBNull.Value);
            command.Parameters.AddWithValue("@phone", ((object)userEntry.Phone) ?? DBNull.Value);
            command.Parameters.AddWithValue("@importance", ((object)userEntry.Importance) ?? DBNull.Value);
            command.Parameters.AddWithValue("@recurence", ((object)userEntry.Recurrence) ?? false);
          /*  command.Parameters.AddWithValue("@recurenceEndDate", ((object)userEntry.RecurrenceEndDate) ?? false);
            command.Parameters.AddWithValue("@recurence", ((object)userEntry.Frequence) ?? false);*/
            command.Parameters.AddWithValue("@reminder", ((object)userEntry.Reminder) ?? false);
            command.Parameters.AddWithValue("@pro", ((object)userEntry.Pro) ?? false);
            command.Parameters.AddWithValue("@perso", ((object)userEntry.Perso) ?? false);
          
            
            
            command.ExecuteNonQuery();
            
            
            
            return userEntry;
        }

         public static Appointment UpdateAppointment(Appointment userEntry)
        {
            SqlCommand command = _connection.CreateCommand();
            SqlCommand storecommand = _connection.CreateCommand();
            
            command.CommandText = "UPDATE Appointment SET Rdv = @rdv, BeginDate = @beginDate, EndDate = @endDate, AppointmentDescription = @description, AppointmentAddress = @address, Contact = @contact, Email = @email, Phone = @phone, Importance = @importance, Recurence = @recurence, Reminder = @reminder, Pro = @pro, Perso = @perso WHERE IdAppointment = @idUserEntry";

            command.Parameters.AddWithValue("@idUserEntry", userEntry.Id);

            storecommand.CommandText = "SELECT Rdv WHERE IdAppointment = @idUserEntry;";
            if (userEntry.Rdv == storecommand.CommandText)
            {
                command.Parameters.AddWithValue("@rdv", storecommand.CommandText);
            }
            else
            {
                command.Parameters.AddWithValue("@rdv", userEntry.Rdv);
            }

            storecommand.CommandText = "SELECT BeginDate WHERE IdAppointment = @idUserEntry;";
            if (Equals(userEntry.BeginDate, storecommand.CommandText))
            {
                command.Parameters.AddWithValue("@beginDate", storecommand.CommandText);
            }
            else
            {
                command.Parameters.AddWithValue("@beginDate", userEntry.BeginDate);
            }

            storecommand.CommandText = "SELECT EndDate WHERE IdAppointment = @idUserEntry;";
            if (Equals(userEntry.EndDate, storecommand.CommandText))
            {
                command.Parameters.AddWithValue("@endDate", storecommand.CommandText);
            }
            else
            {
                command.Parameters.AddWithValue("@endDate", userEntry.EndDate);
            }

            storecommand.CommandText = "SELECT AppointmentDescription WHERE IdAppointment = @idUserEntry;";
            if (userEntry.Description == storecommand.CommandText)
            {
                command.Parameters.AddWithValue("@description", storecommand.CommandText);
            }
            else
            {
                command.Parameters.AddWithValue("@description", userEntry.Description);
            }

            storecommand.CommandText = "SELECT AppointmentAddress WHERE IdAppointment = @idUserEntry;";
            if (userEntry.Address == storecommand.CommandText)
            {
                command.Parameters.AddWithValue("@address", storecommand.CommandText);
            }
            else
            {
                command.Parameters.AddWithValue("@address", userEntry.Address);
            }

            storecommand.CommandText = "SELECT Contact WHERE IdAppointment = @idUserEntry;";
            if (userEntry.Contact == storecommand.CommandText)
            {
                command.Parameters.AddWithValue("@contact", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@contact", userEntry.Contact);
            }

             storecommand.CommandText = "SELECT Email WHERE IdAppointment = @idUserEntry;";
            if (userEntry.Email == storecommand.CommandText)
            {
                command.Parameters.AddWithValue("@email", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@email", userEntry.Email);
            }

              storecommand.CommandText = "SELECT Phone WHERE IdAppointment = @idUserEntry;";
            if (userEntry.Phone == storecommand.CommandText)
            {
                command.Parameters.AddWithValue("@phone", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@phone", userEntry.Phone);
            }

            
              storecommand.CommandText = "SELECT Importance WHERE IdAppointment = @idUserEntry;";
            if (Equals(userEntry.Importance, storecommand.CommandText))
            {
                command.Parameters.AddWithValue("@importance", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@importance", userEntry.Importance);
            }

              storecommand.CommandText = "SELECT Recurence WHERE IdAppointment = @idUserEntry;";
            if (Equals(userEntry.Recurrence, storecommand.CommandText))
            {
                command.Parameters.AddWithValue("@recurence", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@recurence", userEntry.Recurrence);
            }

             storecommand.CommandText = "SELECT Reminder WHERE IdAppointment = @idUserEntry;";
            if (Equals(userEntry.Reminder, storecommand.CommandText))
            {
                command.Parameters.AddWithValue("@reminder", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@reminder", userEntry.Reminder);
            }

            storecommand.CommandText = "SELECT Pro WHERE IdAppointment = @idUserEntry;";
            if (Equals(userEntry.Pro, storecommand.CommandText))
            {
                command.Parameters.AddWithValue("@pro", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@pro", userEntry.Pro);
            }

            storecommand.CommandText = "SELECT Perso WHERE IdAppointment = @idUserEntry;";
            if (Equals(userEntry.Perso, storecommand.CommandText))
            {
                command.Parameters.AddWithValue("@perso", storecommand.CommandText);
            }
            else 
            {
                command.Parameters.AddWithValue("@perso", userEntry.Perso);
            }


            

            //command.Parameters.AddWithValue("@rdv", userEntry.Rdv);
            //command.Parameters.AddWithValue("@beginDate", userEntry.BeginDate);
            //command.Parameters.AddWithValue("@endDate", userEntry.EndDate);
            //command.Parameters.AddWithValue("@description", userEntry.Description);
            //command.Parameters.AddWithValue("@address", userEntry.Address);
            //command.Parameters.AddWithValue("@contact", userEntry.Contact);
            //command.Parameters.AddWithValue("@email", userEntry.Email);
            //command.Parameters.AddWithValue("@phone", userEntry.Phone);
            //command.Parameters.AddWithValue("@importance", userEntry.Importance);
            //command.Parameters.AddWithValue("@recurence", userEntry.Recurrence);
            //command.Parameters.AddWithValue("@reminder", userEntry.Reminder);
            //command.Parameters.AddWithValue("@pro", userEntry.Pro);
            //command.Parameters.AddWithValue("@perso", userEntry.Perso);
            SqlDataReader reader = command.ExecuteReader();

            reader.Close();
            return userEntry;

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
            command.Parameters.AddWithValue("@wordSearch", wordSearch);


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
                }; //On peux aussi appeler les elements avec reader[0] a la place de reader.GetInt32(0)
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
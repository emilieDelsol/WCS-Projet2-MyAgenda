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
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
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

                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectProAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                                "WHERE (Pro=1)" +
                                "ORDER BY BeginDate"; ;
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
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        internal static List<Appointment> SearchByWord(string wordSearch)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv,BeginDate,EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(Recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
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
                    Frequence = reader.GetInt32(11),
                    NumberOfRecurrence = reader.GetInt32(12),
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();

            return appointments;
        }

        public static List<Appointment> SelectPersoAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                                "WHERE (Pro=0)"+
                                "ORDER BY BeginDate" ;
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
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectImportantAppointments(String importanceFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               "WHERE (Importance=@importanceFilter)" +
                                "ORDER BY BeginDate";
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
                    Pro = reader.GetBoolean(13),

                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectImportantProAppointments(String importanceFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               "WHERE(Importance = @importanceFilter AND Pro = 1)" +
                                "ORDER BY BeginDate";
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
                    Pro = reader.GetBoolean(13),

                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectImportantPersoAppointments(String importanceFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               " WHERE (Importance=@importanceFilter AND Pro=0)" +
                                "ORDER BY BeginDate";
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
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        public static List<Appointment> SelectBetweenDate(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               "WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter)" +
                                "ORDER BY BeginDate"; 
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
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }


        public static List<Appointment> SelectBetweenDateImportance(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               "WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Importance = 1)" +
                                "ORDER BY BeginDate"; 
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
                    Pro = reader.GetBoolean(13),

                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectBetweenDatePro(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               "WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Pro = 1)" +
                                "ORDER BY BeginDate";
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
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }
        public static List<Appointment> SelectBetweenDatePerso(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               "WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Pro = 0)" +
                                "ORDER BY BeginDate";
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
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectBetweenDatePersoImportance(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               "WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Pro = 0 AND Importance = 1)" +
                                "ORDER BY BeginDate"; 
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
                    Pro = reader.GetBoolean(13),

                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static List<Appointment> SelectBetweenDateProImportance(String beginDateFilter, String endDateFilter)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT IdAppointment, Rdv, BeginDate, EndDate," +
                                "ISNULL(AppointmentDescription, '')," +
                                "ISNULL(AppointmentAddress, '')," +
                                "ISNULL(Contact, '')," +
                                "ISNULL(Email, '')," +
                                "ISNULL(Phone, '')," +
                                "ISNULL(Importance, 0)," +
                                "ISNULL(recurrence, 0)," +
                                "ISNULL(Frequence, 0)," +
                                "ISNULL(NumberOfRecurrence, 0)," +
                                "ISNULL(Pro, 0)" +
                                "FROM Appointment " +
                               " WHERE (BeginDate>=@beginDateFilter AND BeginDate<=@endDateFilter AND Pro = 1 AND Importance = 1)" +
                                "ORDER BY BeginDate"; 
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
                    Pro = reader.GetBoolean(13),
                };
                appointments.Add(appointment);
            }
            reader.Close();
            return appointments;
        }

        public static bool InsertAppointment(Appointment userEntry)
        {
            SqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, Recurrence, Pro) " +
                "VALUES (@rdv,@beginDate, @endDate, @description, @address, @contact,@email,@phone,@importance,@recurrence,@reminder,@pro,@perso);";

            command.Parameters.AddWithValue("@rdv", userEntry.Rdv);
            command.Parameters.AddWithValue("@beginDate", userEntry.BeginDate);
            command.Parameters.AddWithValue("@endDate", userEntry.EndDate);
            command.Parameters.AddWithNullValue("@description", userEntry.Description);
            command.Parameters.AddWithNullValue("@address", userEntry.Address);
            command.Parameters.AddWithNullValue("@contact", userEntry.Contact);
            command.Parameters.AddWithNullValue("@email", userEntry.Email);
            command.Parameters.AddWithNullValue("@phone", userEntry.Phone);
            command.Parameters.AddWithNullValue("@importance", userEntry.Importance);
            command.Parameters.AddWithDefaultValue("@recurrence", userEntry.Recurrence, false);
            command.Parameters.AddWithNullValue("@frequence", userEntry.Frequence);
            command.Parameters.AddWithNullValue("@numberOfRecurrence", userEntry.NumberOfRecurrence);
            command.Parameters.AddWithDefaultValue("@pro", userEntry.Pro, false);


            command.CommandText = " DECLARE @r INT SET @r = 0 WHILE(@r <= @numberOfRecurrence) BEGIN INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, recurrence, Frequence, NumberOfRecurrence, Pro) " +
                            "VALUES (@rdv,@beginDate+@r, @endDate+@r, @description, @address, @contact,@email,@phone,@importance,@recurrence,@frequence, @numberOfRecurrence,@pro) SET @r = @r + 1 END ;";
            Int32 affectedRowsCount = command.ExecuteNonQuery();
            if (affectedRowsCount < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool UpdateAppointment(Appointment userEntry)
        {

            SqlCommand command = _connection.CreateCommand();

            List<Appointment> myList = DataAbstractionLayer.SelectAllAppointments();
            Appointment registerAppointment = new Appointment();
//            registerAppointment = myList[userEntry.Id];
            foreach(Appointment appointment in myList)
			{
				if (appointment.Id == userEntry.Id)
				{
                    registerAppointment = appointment;
				}
			}

            command.CommandText = "UPDATE Appointment SET (Rdv, BeginDate, EndDate, AppointmentDescription, AppointmentAddress, Contact, Email, Phone, Importance, Recurrence, Pro) " +
                "VALUES (@rdv,@beginDate, @endDate, @description, @address, @contact,@email,@phone,@importance,@recurrence,@reminder,@pro,@perso)";

            command.Parameters.AddWithRegisterValue("@rdv", userEntry.Rdv,registerAppointment.Rdv);
            command.Parameters.AddWithRegisterValue("@beginDate", userEntry.BeginDate,registerAppointment.BeginDate);
            command.Parameters.AddWithRegisterValue("@endDate", userEntry.EndDate, registerAppointment.EndDate);
            command.Parameters.AddWithRegisterValue("@description", userEntry.Description,registerAppointment.Description);
            command.Parameters.AddWithRegisterValue("@address", userEntry.Address,registerAppointment.Address);
            command.Parameters.AddWithRegisterValue("@contact", userEntry.Contact,registerAppointment.Contact);
            command.Parameters.AddWithRegisterValue("@email", userEntry.Email, registerAppointment.Email);
            command.Parameters.AddWithRegisterValue("@phone", userEntry.Phone, registerAppointment.Phone);
            command.Parameters.AddWithRegisterValue("@importance", userEntry.Importance, registerAppointment.Importance);
            command.Parameters.AddWithRegisterValue("@recurrence", userEntry.Recurrence, registerAppointment.Recurrence);
            command.Parameters.AddWithRegisterValue("@frequence", userEntry.Frequence, registerAppointment.Frequence);
            command.Parameters.AddWithRegisterValue("@numberOfRecurrence", userEntry.NumberOfRecurrence, registerAppointment.NumberOfRecurrence);
            command.Parameters.AddWithRegisterValue("@pro", userEntry.Pro, registerAppointment.Pro);

            command.CommandText += " WHERE IdAppointment=@idUserEntry" + ";";
            command.Parameters.AddWithValue("@idUserEntry", userEntry.Id);
            Console.WriteLine(command.CommandText);
            Int32 affectedRowsCount = command.ExecuteNonQuery();
            if (affectedRowsCount < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
            public static HttpResponseMessage DeleteMyAppointment(Appointment appointmentToDelete)
            {
                SqlCommand command = _connection.CreateCommand();

                Appointment appointment = new Appointment();

                appointment.Id = appointmentToDelete.Id;

                command.CommandText = "DELETE Appointment WHERE IdAppointment = @userEntryIdTodelete";

                command.Parameters.AddWithValue("@userEntryIdTodelete", appointment.Id);

                command.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.Accepted);

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
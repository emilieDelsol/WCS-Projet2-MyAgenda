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
            command.CommandText = "SELECT * FROM Appointment";
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
                }; //On peux auusi appeler les elements avec reader[0] a la place de reader.GetInt32(0)
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
                    Importance = reader.GetInt32(9),
                    Recurrence = reader.GetBoolean(10),
                    Pro = reader.GetBoolean(12),
                    Perso = reader.GetBoolean(13)
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
        public static void Close()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
       /* public static SqlConnection GetConnectionPerso()
        {
            return _connection;
        }
        public static List<Appointment> GetPersoAppointments()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE perso=true";
            SqlDataReader readerPerso = command.ExecuteReader();
            List<Appointment> appointments = new List<Appointment>();
            while (readerPerso.Read())
            {
                Appointment appointment = new Appointment { Id = readerPerso.GetInt32(0), Rdv = readerPerso.GetString(1) };
                appointments.Add(appointment);
            }
            return appointments;
        }

        public static void ClosePerso()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }*/
    }
}

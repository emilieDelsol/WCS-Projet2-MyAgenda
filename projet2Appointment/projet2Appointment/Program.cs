using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace projet2Appointment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.InitialCatalog = "MyAgenda";
            stringBuilder.DataSource = @"LOCALHOST\SQLEXPRESS";
            stringBuilder.IntegratedSecurity = true;
            DataAbstractionLayer.Open(stringBuilder);
            CreateHostBuilder(args).Build().Run();
            DataAbstractionLayer.Close();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using AC1_M9UF1.Models;



namespace AC1_M9UF1.Persistence.Utils
{
    public class NpgsqlUtils
    {
        public static string OpenConnection()
        {
            string path = "appsettings.json";
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(path, optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("MyPostgresConnection");
        }

        public static Customer GetCustomer(NpgsqlDataReader reader)
        {
            Customer c = new Customer
            {
                Id = reader.GetInt32(0),
                CompanyName = reader.GetString(1),
                ContactName = reader.GetString(2),
                EmployeesCount = reader.GetInt32(3),
            };
            return c;
        }

    }
}
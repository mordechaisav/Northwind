using Microsoft.Extensions.Configuration;
using System;

namespace Northwind
{
    public class JsonHelper
    {
        public static string GetConnectionString()
        {
            // SET SECRETS.JSON TO COPY ALWAYS AFTER ADDING!!
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("secrets.json", optional: true) // Add secrets.json
                .Build();

            // Read a value from the configuration
            string connString = configuration["ConnectionString"];
            if (string.IsNullOrEmpty(connString))
            {
                throw new Exception("The connection string is missing or empty.");
            }

            return connString;
        }
    }
}

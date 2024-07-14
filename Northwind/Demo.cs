using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;

namespace Northwind
{
    public class Demo
    {
        public void FetchEmployees()
        {
            string connString = JsonHelper.GetConnectionString();
            using (SqlConnection myConnection = new SqlConnection(connString))
            {
                myConnection.Open();

                string query = "SELECT * FROM Employees";
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var employees = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var employee = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                employee[reader.GetName(i)] = reader.GetValue(i);
                            }
                            employees.Add(employee);
                        }

                        string jsonString = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
                        Console.WriteLine(jsonString);
                    }
                }
            }
        }

        public void FetchCustomers()
        {
            string connString = JsonHelper.GetConnectionString();
            using (SqlConnection myConnection = new SqlConnection(connString))
            {
                myConnection.Open();

                string query = "SELECT * FROM Customers";
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var customers = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var customer = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                customer[reader.GetName(i)] = reader.GetValue(i);
                            }
                            customers.Add(customer);
                        }

                        string jsonString = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
                        Console.WriteLine(jsonString);
                    }
                }
            }
        }

        public void GetCustomerByID()
        {
            string connString = JsonHelper.GetConnectionString();
            string ID = Console.ReadLine();
            using (SqlConnection myConnection = new SqlConnection(connString))
            {
                myConnection.Open();

                
                string query = $"SELECT * FROM Customers WHERE CustomerID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var customers = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var customer = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                customer[reader.GetName(i)] = reader.GetValue(i);
                            }
                            customers.Add(customer);
                        }

                        string jsonString = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
                        Console.WriteLine(jsonString);
                    }
                }
            }
        }
    }
}

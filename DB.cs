using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace Alexander_Fearday_Unit2_IT481
{
    class DB
    {
        string connectionString;
        SqlConnection cnn;

        public DB()
        {
            connectionString = "Server = DESKTOP-4J19U6L\\SQLEXPRESS;" + "Trusted_Connection=true;" + "Database=northwind;" + "User Instance=false;" + "Connection timeout=30";
        }
        public DB(string conn)
        {
            connectionString = conn;
        }
        public string getCustomerCount()
        {
            Int32 count = 0;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select count (*) from dbo.Customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count.ToString();
        }
        public string getCustomerName()
        {
            string names = "None";
            SqlDataReader dataReader;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select companyname from dbo.Customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetString(0) + "\n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return names;
        }
        public string getOrderCount()
        {
            Int32 count = 0;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select count(*) from dbo.Orders;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count.ToString();
        }
        public string getOrders()
        {
            string names = "None";
            SqlDataReader dataReader;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select orderid from dbo.Orders;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return names;
        }
        public string getEmployeeCount()
        {
            Int32 count = 0;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuerry = "select count(*) from dbo.Employees";
            SqlCommand cmd = new SqlCommand(countQuerry, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count.ToString();
        }
        public string getEmployeeLastName()
        {
            string names = "None";
            SqlDataReader dataReader;

            cnn = new SqlConnection((connectionString));
            cnn.Open();
            string countQuerry = " select lastname from employees";
            SqlCommand cmd = new SqlCommand(countQuerry, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return names;
        }
    }
}

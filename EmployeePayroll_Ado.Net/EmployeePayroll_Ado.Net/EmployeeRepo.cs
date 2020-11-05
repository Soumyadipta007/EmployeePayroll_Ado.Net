using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll_Ado.Net
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-JQ4KIAJ\SQLEXPRESS;Initial Catalog=Payroll_Service_DB;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void checkConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("Connection established");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }        
    }
}


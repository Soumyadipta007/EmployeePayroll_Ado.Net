﻿using System;
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
                this.connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.BasicPay = dr.GetDecimal(2);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(6);
                            employeeModel.Department = dr.GetString(7);
                            employeeModel.Deductions = dr.GetDouble(8);
                            employeeModel.TaxablePay = dr.GetSqlSingle(9);
                            employeeModel.Tax = dr.GetDouble(10);
                            employeeModel.NetPay = dr.GetSqlSingle(11);
                            System.Console.WriteLine(employeeModel.EmployeeID + " " + employeeModel.EmployeeName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.Deductions + " " + employeeModel.TaxablePay + " " + employeeModel.Tax + " " + employeeModel.NetPay);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


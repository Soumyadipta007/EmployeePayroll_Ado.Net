using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;

namespace EmployeePayroll_Ado.Net
{
    public class EmployeeRepo
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
            catch (Exception e)
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
        public Decimal updateSalary()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"update employee_payroll set basic_pay=3000000 where name='Teresa';";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        query = @"Select basic_pay from employee_payroll where name='Teresa';";
                        cmd = new SqlCommand(query, connection);
                        object res = cmd.ExecuteScalar();
                        employeeModel.BasicPay = (decimal)res;
                        return (employeeModel.BasicPay);                                                                                                  
                    }
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<string> GetEmployeesJoiningAfterADate()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            List<string> results = new List<string>();
            try
            {
                using (connection)
                {
                    string query = @"SELECT * FROM employee_payroll where start between CAST('2018-01-01' AS DATE) AND CAST('2020-11-05' AS DATE)";
                    SqlCommand command = new SqlCommand(query, connection);
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("YeS");
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
                            results.Add(employeeModel.EmployeeName);
                        }
                        dr.Close();
                        return results;
                    }
                    else
                    {
                        throw new Exception("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void GetAggregateSalaryDetailsByGender()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                string query = @"select Gender,SUM(basic_pay),AVG(basic_pay),MIN(basic_pay),MAX(basic_pay),COUNT(id)
                               from employee_payroll group by gender";
                SqlCommand command = new SqlCommand(query, this.connection);
                this.connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("Gender\tSUM\t\tAVG\t\tMIN\t\tMAX\t\tCount");
                    while (dr.Read())
                    {
                        string gender = dr.GetString(0);
                        decimal SUM = dr.GetDecimal(1);
                        decimal AVG = dr.GetDecimal(2);
                        decimal MIN = dr.GetDecimal(3);
                        decimal MAX = dr.GetDecimal(4);
                        int Count = dr.GetInt32(5);
                        Console.WriteLine(gender + "\t" + SUM + "\t" + AVG + "\t" + MIN + "\t" + MAX + "\t" + Count);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No such records found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}


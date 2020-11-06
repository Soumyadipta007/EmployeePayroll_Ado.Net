using System;

namespace EmployeePayroll_Ado.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll!");
            EmployeeRepo repo = new EmployeeRepo();
            repo.checkConnection();
            repo.GetAllEmployee();           
        }
    }
}

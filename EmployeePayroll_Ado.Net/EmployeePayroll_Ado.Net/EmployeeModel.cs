using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Numerics;
using System.Text;

namespace EmployeePayroll_Ado.Net
{
    class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public decimal BasicPay { get; set; }
        public double Deductions { get; set; }
        public SqlSingle TaxablePay { get; set; }
        public double Tax { get; set; }
        public SqlSingle NetPay { get; set; }
        public DateTime StartDate { get; set; }
    }
}

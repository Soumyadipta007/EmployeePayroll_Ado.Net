using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll_Ado.Net;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenQueryUpdateSalary()
        {
            EmployeeRepo repo = new EmployeeRepo();
            Assert.AreEqual(3000000, repo.updateSalary());
        }
        [TestMethod]
        public void GivenQueryUpdateSalary2()
        {
            EmployeeRepo repo = new EmployeeRepo();
            Assert.AreEqual(3000000, repo.updateSalary());
        }
        [TestMethod]
        public void GivenDateRangeGetEmployeeName()
        {
            EmployeeRepo repo = new EmployeeRepo();
            var result = repo.GetEmployeesJoiningAfterADate();
            Assert.AreEqual("Bill", result[0]);
        }        
    }
}

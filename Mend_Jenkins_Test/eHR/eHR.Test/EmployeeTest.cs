using Azure;
using eHR.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLog.LayoutRenderers.Wrappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestInitialize]
        public void Test()
        {

        }

        [TestCleanup]
        public void Test2()
        {

        }

        [TestMethod]
        public void GetEmployeeByConditionFromDB()
        {
            //Arrange
            eHR.Dao.EmployeeDao employeeDao = new Dao.EmployeeDao(new eHR.Dao.DataAccessTool());
            eHR.Model.EmployeeSearchArg employeeSearchArg= new eHR.Model.EmployeeSearchArg();
            employeeSearchArg.HireDateStart = "2000/01/01";

            //Act
            var testResult=employeeDao.GetEmployeesByCondition(employeeSearchArg).Any();

            
            //Assert
            Assert.AreEqual(true, testResult);
        }

        public void GetEmployeeByConditionMockDB()
        {
            //Arrang
            DataTable dt = GetEmployeeMockDataTable();

            var mock=new Mock<eHR.Dao.IDataAccessTool>();
            mock.Setup(m => m.Query(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<KeyValuePair<string, object>>>())).Returns(dt);
            
            eHR.Dao.EmployeeDao employeeDao=new Dao.EmployeeDao(mock.Object);
            //Act
            var testResult = employeeDao.GetEmployeesByCondition(new EmployeeSearchArg()).Any();

            //Assert
            Assert.AreEqual(true,testResult);
        }

        [TestMethod]
        public void GetEmployeeByConditionMockDAO()
        {
            //Arrange
            var employeeList = GetEmployeeMockList();
            var mock=new Mock<eHR.Dao.IEmployeeDao>();

            mock.Setup(m => m.GetEmployeesByCondition(It.IsAny<eHR.Model.EmployeeSearchArg>())).Returns(employeeList);

            eHR.Service.EmployeeService employeeService = new Service.EmployeeService(mock.Object);
            //Act

            var testResult = employeeService.GetEmployeesByCondition(new EmployeeSearchArg()).Any();
            //Assert

            
            Assert.AreEqual(true,testResult);
        }


        private DataTable GetEmployeeMockDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("EmployeeID");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("JobTitleId");
            dt.Columns.Add("JobTitle");
            dt.Columns.Add("TitleOfCourtesy");
            dt.Columns.Add("HireDate");
            dt.Columns.Add("BirthDate");
            dt.Columns.Add("Age");
            dt.Columns.Add("Address");
            dt.Columns.Add("City");
            dt.Columns.Add("Country");
            dt.Columns.Add("GenderId");
            dt.Columns.Add("Gender");
            dt.Columns.Add("ManagerID");
            dt.Columns.Add("Phone");
            dt.Columns.Add("MonthlyPayment");
            dt.Columns.Add("YearlyPayment");

            dt.Rows.Add("1", "Sara", "Davis", "0001", "CEO", "Ms.", "2002-05-01", "1958-12-08", "22", "7890 - 20th Ave. E., Apt. 2A", "0005", "USA", "F", "Female", "NULL", "(206) 555-0101", "NULL", "NULL");

            return dt;
        }

        private List<eHR.Model.Employee> GetEmployeeMockList()
        {
            var result= new List<eHR.Model.Employee>
            {
                new Employee()
                {
                    EmployeeId = 1,
                    EmployeeFirstName = "Sara",
                    EmployeeLastName = "Davis",
                    JobTitleId = "0001",
                    JobTitle = "CEO",
                    TitleOfCourtesy = "Ms.",
                    HireDate = "2002-05-01",
                    BirthDate = "1958-12-08",
                    Age = 22,
                    Address = "7890 - 20th Ave. E., Apt. 2A",
                    City = "0005",
                    Country = "USA",
                    GenderId = "F",
                    Gender = "Female",
                    ManagerId = null,
                    Phone = "(206) 555-0101",
                    MonthlyPayment = null,
                    YearlyPayment = null
                }
            };
            return result;
        }
    }

}

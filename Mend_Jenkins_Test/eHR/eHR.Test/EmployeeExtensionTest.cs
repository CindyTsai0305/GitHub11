using eHR.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;

namespace eHR.Test
{
    [TestClass]
    public class EmployeeExtensionTest
    {

        [TestMethod]
        public void MaskPaymentWhenTheBoos()
        {
            //Arrange

            var mock=new Mock<IDataAccessTool>();

            #region mock Datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeID");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("JobTitle");
            dt.Columns.Add("JobTitleId");
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

            dt.Rows.Add("1", "Sara", "Sys", "0001", "CEO",
                        "Ms.", "2002-05-01", "1958-12-08", "64", "7890 - 20th Ave. E., Apt. 2A",
                        "0005", "USA", "F", "Female", "", "(206) 555-0101", "0", "0");
            #endregion

            mock.Setup(m => m.Query(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<List<KeyValuePair<string, object>>>())).Returns(dt);

            var employeeDao = new EmployeeDao(mock.Object);

            //Act
            var empployee = employeeDao.GetEmployeesByCondition(new Model.EmployeeSearchArg()).FirstOrDefault();
            //Assert
            Assert.AreEqual(empployee.MonthlyPayment, "*****");
        }

        [TestMethod]
        public void MaskPaymentWhenTheBoosUseServiceFunction()
        {
            //Arrange
            eHR.Service.EmployeeService employeeService = 
                new Service.EmployeeService(new eHR.Dao.EmployeeDao(new eHR.Dao.DataAccessTool()));

            List<eHR.Model.Employee> employeeList = new List<Model.Employee>();
            employeeList.Add(new Model.Employee()
            {
                ManagerId = "",
                MonthlyPayment = "12345"
            });
            
            //Act
            employeeService.MaskBossPayment(employeeList);
            //Assert
            Assert.AreEqual(employeeList.FirstOrDefault().MonthlyPayment, "*****");
        }
    }
}
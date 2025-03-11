using eHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly eHR.Dao.IEmployeeDao _employeeDao;
        public EmployeeService(eHR.Dao.IEmployeeDao employeeDao) 
        { 
            _employeeDao= employeeDao;
        }
        /// <summary>
        /// 依查詢條件取得員工資料
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeesByCondition(EmployeeSearchArg arg)
        {
            //eHR.Dao.EmployeeDao employeeDao = new eHR.Dao.EmployeeDao();
            return _employeeDao.GetEmployeesByCondition(arg);
        }

        /// <summary>
        /// 新增員工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string InsertEmployee(Employee employee)
        {
            //eHR.Dao.EmployeeDao employeeDao = new Dao.EmployeeDao();
            return _employeeDao.InsertEmployee(employee);
        }

        public void DeleteEmployeeById(string employeeId)
        {
            //eHR.Dao.EmployeeDao employeeDao = new eHR.Dao.EmployeeDao();
            _employeeDao.DeleteEmployeeById(employeeId);
        }

        /// <summary>
        /// 對大老闆的薪資做遮罩
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public List<Employee> MaskBossPayment(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                item.MonthlyPayment = string.IsNullOrEmpty(item.ManagerId) ? eHR.Common.StringTool.MaskString("*", 5) : item.MonthlyPayment;
                item.YearlyPayment = string.IsNullOrEmpty(item.ManagerId) ? eHR.Common.StringTool.MaskString("*", 5) : item.YearlyPayment;
            }
            return employees;
        }
    }
}

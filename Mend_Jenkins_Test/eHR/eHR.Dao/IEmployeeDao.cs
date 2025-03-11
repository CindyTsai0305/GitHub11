using eHR.Model;

namespace eHR.Dao
{
    public interface IEmployeeDao
    {
        void DeleteEmployeeById(string employeeId);
        List<Employee> GetEmployeesByCondition(EmployeeSearchArg arg);
        string InsertEmployee(Employee employee);
    }
}
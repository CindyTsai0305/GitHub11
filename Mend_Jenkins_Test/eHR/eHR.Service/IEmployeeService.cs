using eHR.Model;

namespace eHR.Service
{
    public interface IEmployeeService
    {
        void DeleteEmployeeById(string employeeId);
        List<Employee> GetEmployeesByCondition(EmployeeSearchArg arg);
        string InsertEmployee(Employee employee);

        List<Employee> MaskBossPayment(List<Employee> employees);
    }
}
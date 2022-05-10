using JWT_Test.Models;

namespace JWT_Test.Services
{
    public interface IEmployeeInterface
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}

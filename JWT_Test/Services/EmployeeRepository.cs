using JWT_Test.DataLayer;
using JWT_Test.Models;

namespace JWT_Test.Services
{
    public class EmployeeRepository : IEmployeeInterface
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return employee;
        }

        public void DeleteEmployee(int id)
        {
            _dbContext.Employees.Remove(_dbContext.Employees.FirstOrDefault(e => e.EmployeeID == id));
        }

        public Employee EditEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();

            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }

        public List<Employee> GetEmployees()
        {
            return _dbContext.Employees.ToList();
        }
    }
}

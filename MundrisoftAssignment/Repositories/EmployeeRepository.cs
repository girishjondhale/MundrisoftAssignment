using Microsoft.EntityFrameworkCore;
using MundrisoftAssignment.Data;
using MundrisoftAssignment.Models;

namespace MundrisoftAssignment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public int AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return _dbContext.SaveChanges();
        }

        public int UpdateEmployee(Employee editedEmployee)
        {
            int res = 0;
            Employee emp = new Employee();
            emp = _dbContext.Employees.Where(x => x.EmployeeId == editedEmployee.EmployeeId).FirstOrDefault();
            if (emp != null)
            {
                emp.EmployeeName = editedEmployee.EmployeeName;
                emp.Email = editedEmployee.Email;
                emp.City = editedEmployee.City;
                emp.DepartmentId = editedEmployee.DepartmentId;
                res = _dbContext.SaveChanges();
            }
            return res;
        }

        public int DeleteEmployee(int id)
        {
            int res = 0;
            var employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                res= _dbContext.SaveChanges();
            }
            return res;
        }
    }
}

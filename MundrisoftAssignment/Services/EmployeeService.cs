using MundrisoftAssignment.Models;
using MundrisoftAssignment.Repositories;

namespace MundrisoftAssignment.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public int AddEmployee(Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        public int UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        public int DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
    }

}

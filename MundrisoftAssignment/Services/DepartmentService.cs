using MundrisoftAssignment.Models;
using MundrisoftAssignment.Repositories;

namespace MundrisoftAssignment.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int AddDepartment(Department department)
        {
            return _departmentRepository.AddDepartment(department);
        }

        public int DeleteDepartment(int id)
        {
            return _departmentRepository.DeleteDepartment(id);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetDepartmentById(id);
        }

        public int UpdateDepartment(Department department)
        {
            return _departmentRepository.UpdateDepartment(department);
        }
    }
}

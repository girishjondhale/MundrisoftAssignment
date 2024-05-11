using MundrisoftAssignment.Models;

namespace MundrisoftAssignment.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        int AddDepartment(Department department);
        int UpdateDepartment(Department department);
        int DeleteDepartment(int id);
    }
}

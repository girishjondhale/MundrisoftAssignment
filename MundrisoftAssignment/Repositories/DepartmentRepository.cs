using MundrisoftAssignment.Data;
using MundrisoftAssignment.Models;

namespace MundrisoftAssignment.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddDepartment(Department department)
        {
            _dbContext.department.Add(department);
            return _dbContext.SaveChanges();
        }

        public int DeleteDepartment(int id)
        {
            int res = 0;
            var dep = _dbContext.department.FirstOrDefault(e => e.DepartmentId == id);
            if (dep != null)
            {
                _dbContext.department.Remove(dep);
                res = _dbContext.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _dbContext.department.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _dbContext.department.FirstOrDefault(e => e.DepartmentId == id);
        }

        public int UpdateDepartment(Department department)
        {
            int res = 0;
            Department dep = new Department();
            dep = _dbContext.department.Where(x => x.DepartmentId == department.DepartmentId).FirstOrDefault();
            if (dep != null)
            {
                dep.DepartmentName = department.DepartmentName;
                res = _dbContext.SaveChanges();
            }
            return res;
        }
    }
}

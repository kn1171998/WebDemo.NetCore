using PayCompute.Entity;
using PayCompute.Persistence;

namespace PayCompute.Service.Implementation
{
    public interface IDepartmentService : IBaseService<Department>
    {
    }

    public class DepartmentService : RepositoryBaseService<Department>, IDepartmentService
    {
        public DepartmentService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
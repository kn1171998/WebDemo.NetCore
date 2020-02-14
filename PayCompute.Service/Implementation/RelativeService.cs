using PayCompute.Entity;
using PayCompute.Persistence;

namespace PayCompute.Service.Implementation
{
    public interface IRelativeService : IBaseService<Relative> { }

    public class RelativeService : RepositoryBaseService<Relative>, IRelativeService
    {
        public RelativeService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
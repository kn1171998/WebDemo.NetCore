using PayCompute.Entity;
using PayCompute.Persistence;

namespace PayCompute.Service.Implementation
{
    public interface ILocationService : IBaseService<Location>
    {
    }

    public class LocationService : RepositoryBaseService<Location>, ILocationService
    {
        public LocationService(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}
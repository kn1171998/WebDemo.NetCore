using PayCompute.Entity;
using PayCompute.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace PayCompute.Service.Implementation
{
    public interface ILocationEmployeeService : IBaseService<LocationEmployee>
    {
        public IEnumerable<Location> LoadLocation_FlowPos(int id);
    }

    public class LocationEmployeeService : RepositoryBaseService<LocationEmployee>, ILocationEmployeeService
    {
        public LocationEmployeeService(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Location> LoadLocation_FlowPos(int id)
        {
            var a = _context.Locations.Where(t => t.PositionJobId == id).Select(t => t);
            return a;
        }
    }
}
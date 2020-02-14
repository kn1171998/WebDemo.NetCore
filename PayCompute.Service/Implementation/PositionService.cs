using PayCompute.Entity;
using PayCompute.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayCompute.Service.Implementation
{
    public interface IPositionService : IBaseService<PositionJob> { }
    public class PositionService : RepositoryBaseService<PositionJob>, IPositionService
    {
        public PositionService(ApplicationDbContext context) : base(context)
        {
        }
    }
}

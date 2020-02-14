using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Models.LocationEmployee
{
    public class LocationEmployeeCreateViewModel
    {
        public DateTime datejoined { get; set; }
        public string PositionName { set; get; }
        public string LocationName { set; get; }
        public int PositionId { set; get; }
        public int LocationId { set; get; }
        public int EmployeeId { set; get; }
        public string EmployeeName { set; get; }
    }
}

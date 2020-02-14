using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Models.Location
{
    public class LocationCreateViewModel
    {
        public int Id { set; get; }
        [Required,StringLength(100)]
        public string LocationName { set; get; }
        [Required]
        public int DepartmentId { set; get; }
        [Required]
        public int PositionJobId { set; get; }
    }
}

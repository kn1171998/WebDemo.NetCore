using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCompute.Entity
{
    public class Location
    {
        public int Id { set; get; }

        [Required, MaxLength(50)]
        public string LocationName { set; get; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { set; get; }

        public Department Department { set; get; }

        [ForeignKey("PositionJobId")]
        public int PositionJobId { set; get; }

        public PositionJob PositionJob { set; get; }

        public IEnumerable<LocationEmployee> LocationEmployees { set; get; }
        public bool Status { set; get; }
    }
}
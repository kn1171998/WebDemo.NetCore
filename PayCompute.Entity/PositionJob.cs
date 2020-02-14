using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCompute.Entity
{

    public class PositionJob
    {
        public int Id { set; get; }
        [Required, MaxLength(50)]
        public string PositionJobCode { set; get; }
        [Required, MaxLength(250)]
        public string PositionJobName { set; get; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InsuranceMoney { set; get; }
        public bool Status { set; get; }
        public IEnumerable<Location> Location { set; get; }
    }
}
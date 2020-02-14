using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCompute.Entity
{
    public class LocationEmployee
    {

        [Key]
        [DataType(DataType.Date)]
        public DateTime DateJoinedLocation { set; get; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { set; get; }
        public int EmployeeId { set; get; }

        [ForeignKey("LocationId")]
        public Location Location { set; get; }
        public int LocationId { set; get; }
        public bool StatusJoindLocation { set; get; }
        public bool Status { set; get; }
    }
}
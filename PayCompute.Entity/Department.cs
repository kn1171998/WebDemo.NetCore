using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayCompute.Entity
{
    public class Department
    {
        public int Id { set; get; }

        [Required, MaxLength(50)]
        public string DepartmentCode { set; get; }

        [Required, MaxLength(250)]
        public string DepartmentName { set; get; }

        [Required, MaxLength(250)]
        public string Address { set; get; }

        public bool Status { set; get; }

        public IEnumerable<Location> Location { set; get; }
    }
}
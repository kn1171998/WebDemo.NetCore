using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCompute.Entity
{
    public class Relative
    {
        public int Id { set; get; }

        [Required, MaxLength(50)]
        public string Name { set; get; }

        [Required, MaxLength(7)]
        public string Gender { set; get; }

        [Required]
        public Relationship Relationship { set; get; }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { set; get; }

        [ForeignKey("Employee")]
        public int EmployeeId { set; get; }

        public Employee Employee { set; get; }
        public bool Status { set; get; }
    }
}
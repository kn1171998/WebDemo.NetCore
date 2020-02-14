using PayCompute.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PayCompute.Models.Relative
{
    public class RelativeEditViewModel
    {
        public int Id { set; get; }

        [Required, StringLength(50, ErrorMessage = "Please enter less than 50 characters!")]
        public string Name { get; set; }

        [Required]
        public string Gender { set; get; }

        [Required]
        public Relationship Relationship { set; get; }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { set; get; }

        public int EmployeeId { set; get; }
    }
}
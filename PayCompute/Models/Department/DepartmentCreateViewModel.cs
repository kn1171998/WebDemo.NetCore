using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Models.Department
{
    
    public class DepartmentCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Required"), 
            StringLength(50, ErrorMessage ="Please enter less than 50 characters!")]
        public string DepartmentCode { set; get; }

        [Required(ErrorMessage = "Required"), 
            StringLength(50, ErrorMessage = "Please enter less than 50 characters!"), 
            Display(Name ="Department Name")]
        public string DepartmentName { set; get; }

        [Required(ErrorMessage = "Required"),
            StringLength(50, ErrorMessage = "Please enter less than 50 characters!")]
        public string Address { set; get; }

        public bool Status { set; get; }
    }
}

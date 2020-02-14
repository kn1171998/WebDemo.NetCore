using System.ComponentModel.DataAnnotations;

namespace PayCompute.Models.Department
{
    public class DepartmentEditViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Required"),
        StringLength(50, ErrorMessage = "Please enter less than 50 characters!")]
        public string DepartmentCode { set; get; }

        [Required(ErrorMessage = "Required"),
            StringLength(50, ErrorMessage = "Please enter less than 50 characters!"),
            Display(Name = "Department Name")]
        public string DepartmentName { set; get; }

        [Required(ErrorMessage = "Required"),
            StringLength(50, ErrorMessage = "Please enter less than 50 characters!")]
        public string Address { set; get; }
    }
}
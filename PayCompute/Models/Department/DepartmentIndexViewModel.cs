using System.ComponentModel.DataAnnotations;

namespace PayCompute.Models.Department
{
    public class DepartmentIndexViewModel
    {
        public int Id { set; get; }


        public string DepartmentCode { set; get; }


        public string DepartmentName { set; get; }

        public string Address { set; get; }
    }
}
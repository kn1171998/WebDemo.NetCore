using PayCompute.Entity;
using System;

namespace PayCompute.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; }

        public string EmployeeId { set; get; }
        public string EmployeeName { get; set; }
        public string Gender { set; get; }
        public string ImageUrl { set; get; }
        public DateTime DOB { get; set; }
        public string Email { set; get; }
        public string Address { set; get; }

        public DateTime DateJoined { set; get; }

        public string Phone { set; get; }

        public string NationalInsuranceNo { set; get; }

        public PaymentMethod PaymentMethod { set; get; }
    }
}
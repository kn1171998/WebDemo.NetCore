using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayCompute.Entity
{
    public class Employee
    {
        public int Id { set; get; }

        [Required, MaxLength(50)]
        public string EmployeeId { set; get; }

        [Required, MaxLength(50)]
        public string EmployeeName { set; get; }

        [Required, MaxLength(250)]
        public string Address { set; get; }

        [Required, MaxLength(20)]
        public string Phone { set; get; }

        [DataType(DataType.Date)]
        public DateTime DOB { set; get; }

        [Required, MaxLength(7)]
        public string Gender { set; get; }

        [Required, MaxLength(50)]
        public string NumberIdentify { set; get; }

        public string ImageUrl { set; get; }

        [DataType(DataType.Date)]
        public DateTime DateJoined { set; get; }

        [Required, MaxLength(50)]
        public string NationalInsuranceNo { set; get; }

        [Required]
        public PaymentMethod PaymentMethod { set; get; }

        [Required, MaxLength(50)]
        public string Email { set; get; }

        public bool Status { set; get; }
        public IEnumerable<LocationEmployee> LocationEmployees { set; get; }
    }
}
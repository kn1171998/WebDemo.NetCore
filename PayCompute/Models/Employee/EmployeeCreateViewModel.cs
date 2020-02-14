using Microsoft.AspNetCore.Http;
using PayCompute.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PayCompute.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Number is required"),
            RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeId { set; get; }

        [Required(ErrorMessage = "Last Name is required"),
        StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter from 2 to 50 characters!")]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Last Name")]
        public string EmployeeName { set; get; }

        public string Gender { set; get; }

        [Display(Name = "Photo")]
        public IFormFile ImageUrl { set; get; }

        [DataType(DataType.Date), Display(Name = "Date Of Birth")]
        public DateTime DOB { set; get; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter number phone!")]
        public string Phone { set; get; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter Email!")]
        public string Email { set; get; }

        [Required, StringLength(50, ErrorMessage = "Please enter less than 50 characters!"), Display(Name = "NI No.")]
        public string NationalInsuranceNo { set; get; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { set; get; }

        [Required, StringLength(250, ErrorMessage = "Please enter less than 250 characters!")]
        public string Address { set; get; }

        [Required, StringLength(50, ErrorMessage = "Please enter less than 50 characters!")]
        public string NumberIdentify { set; get; }
        
        [DataType(DataType.Date), Display(Name = "Date Join:")]
        public DateTime DateJoined { set; get; }
    }
}
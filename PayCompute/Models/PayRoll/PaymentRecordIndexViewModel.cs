using PayCompute.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Models.Payroll
{
    public class PaymentRecordIndexViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { set; get; }
        [Display(Name ="Name")]
        public string FullName { set; get; }
        [Display(Name = "Pay Date")]
        public DateTime PayDate { set; get; }
        [Display(Name = "Month")]
        public string PayMonth { set; get; }
        public int TaxYearId { set; get; }
        public string Year { get; set;}
        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { set; get; }
        [Display(Name = "Total Deductions")]
        public decimal TotalDeduction { set; get; }
        [Display(Name = "Net")]
        public decimal NetPayment { set; get; }

    }
}

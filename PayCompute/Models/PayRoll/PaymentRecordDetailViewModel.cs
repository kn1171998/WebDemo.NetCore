using PayCompute.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PayCompute.Models.Payroll
{
    public class PaymentRecordDetailViewModel
    {
        public int Id { set; get; }

        [Display(Name = "Full Name")]
        public int EmployeeId { set; get; }

        public Employee Employee { set; get; }

        [Display(Name = "Employee")]
        public string FullName { set; get; }

        public string NiNo { set; get; }

        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate
        {
            get; set;
        }

        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; }

        [Display(Name = "Tax Year")]
        public int TaxYearId { set; get; }

        public TaxYear TaxYear { set; get; }
        public string Year { set; get; }

        [Display(Name = "Tax Code")]
        public string TaxCode { set; get; }

        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { set; get; }

        [Display(Name = "Hourly Worked")]
        public decimal HoursWorked { set; get; }

        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { set; get; } = 144m;

        [Display(Name = "Overtime Hours")]
        public decimal OvertimeHours { set; get; }

        [Display(Name = "Contractual Earnings")]
        public decimal ContractualEarnings { set; get; }

        [Display(Name = "Overtime Earnings")]
        public decimal OvertimeEarnings { set; get; }

        public decimal Tax { set; get; }

        public decimal NIC { set; get; }

        [Display(Name = "Union Fee")]
        public decimal? UnionFee { set; get; }

        public Nullable<decimal> SLC { set; get; }

        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { set; get; }

        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction { set; get; }

        [Display(Name = "Net Payment")]
        public decimal NetPayment { set; get; }
    }
}
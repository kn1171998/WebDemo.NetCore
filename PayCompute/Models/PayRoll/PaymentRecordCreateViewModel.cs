using PayCompute.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PayCompute.Models.Payroll
{
    public class PaymentRecordCreateViewModel
    {
        public int Id { set; get; }

        [Display(Name = "Full Name")]
        public int EmployeeId { set; get; }

        public Employee Employee { set; get; }

        public string FullName { set; get; }
        public string NiNo { set; get; }

        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        [Display(Name = "Pay Month")]
        public string PayMonth { get { return DateTime.Today.Month.ToString(); } }

        [Display(Name = "Tax Year")]
        public int TaxYearId { set; get; }

        public TaxYear TaxYear { set; get; }
        public string TaxCode { set; get; } = "1250L";

        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { set; get; }

        [Display(Name = "Hourly Worked")]
        public decimal HoursWorked { set; get; }

        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { set; get; } = 144m;

        public decimal OvertimeHours { set; get; }

        public decimal ContractualEarnings { set; get; }

        public decimal OvertimeEarnings { set; get; }

        public decimal Tax { set; get; }

        public decimal NIC { set; get; }

        public decimal? UnionFee { set; get; }

        public Nullable<decimal> SLC { set; get; }

        public decimal TotalEarnings { set; get; }

        public decimal TotalDeduction { set; get; }

        public decimal NetPayment { set; get; }
    }
}
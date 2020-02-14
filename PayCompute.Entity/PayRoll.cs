using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCompute.Entity
{
    public class PayRoll
    {
        public int Id { set; get; }

        [ForeignKey("Employee")]
        public int EmployeeId { set; get; }

        public Employee Employee { set; get; }
        public DateTime DatePay { set; get; }

        [ForeignKey("TaxYear")]
        public int TaxYearId { set; get; }

        public TaxYear TaxYear { set; get; }

        [Column(TypeName = "money")]
        public decimal HourlyRate { set; get; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursWorked { set; get; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ContractualHours { set; get; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OvertimeHours { set; get; }

        [Column(TypeName = "money")]
        public decimal ContractualEarnings { set; get; }

        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { set; get; }

        [Column(TypeName = "money")]
        public decimal Tax { set; get; }

        [Column(TypeName = "money")]
        public decimal ReduceFamilyCircumstances { set; get; }

        [Column(TypeName = "money")]
        public decimal NIC { set; get; }

        [Column(TypeName = "money")]
        public decimal TotalEarnings { set; get; }

        [Column(TypeName = "money")]
        public decimal TotalDeduction { set; get; }

        [Column(TypeName = "money")]
        public decimal NetPayment { set; get; }
    }
}
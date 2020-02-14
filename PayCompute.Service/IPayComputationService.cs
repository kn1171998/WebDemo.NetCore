using PayCompute.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCompute.Service
{
    public interface IPayComputationService
    {
        Task CreateAsync(PayRoll PayRoll);

        PayRoll GetById(int id);

        TaxYear GetTaxYearById(int id);

        IEnumerable<PayRoll> GetAll();

        //IEnumerable<SelectListItem> GetAllTaxYear();

        decimal OvertimeHours(decimal hoursWorked, decimal contractualHours);

        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);

        decimal OvertimeRate(decimal hourlyRate);

        decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours);

        decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings);

        decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees);

        decimal NetPay(decimal totalEarnings, decimal totalDeduction);
    }
}
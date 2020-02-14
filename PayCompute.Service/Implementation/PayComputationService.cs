using PayCompute.Entity;
using PayCompute.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Service.Implementation
{
    public class PayComputationService : IPayComputationService
    {
        private decimal contractualEarnings;
        private decimal overtimeHours;
        private readonly ApplicationDbContext _context;

        public PayComputationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PayRoll PayRoll)
        {
            await _context.PayRolls.AddAsync(PayRoll);
            await _context.SaveChangesAsync();
        }

        public PayRoll GetById(int id) => _context.PayRolls.Where(pay => pay.Id == id).FirstOrDefault();

        public IEnumerable<PayRoll> GetAll() => _context.PayRolls.OrderBy(p => p.EmployeeId);

        //public IEnumerable<SelectListItem> GetAllTaxYear()
        //{
        //    var allTaxYear = _context.TaxYears.Select(taxYears => new SelectListItem
        //    {
        //        Text = taxYears.YearOfTax,
        //        Value = taxYears.Id.ToString()
        //    });
        //    return allTaxYear;
        //}

        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked < contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else if (hoursWorked > contractualHours)
            {
                overtimeHours = hoursWorked - contractualHours;
            }
            return overtimeHours;
        }

        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public decimal OvertimeRate(decimal hourlyRate) => hourlyRate * 1.5m;

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours) => overtimeRate * overtimeHours;

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
            => overtimeEarnings + contractualEarnings;

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees)
            => tax + nic + studentLoanRepayment + unionFees;

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction) => totalEarnings - totalDeduction;

        public TaxYear GetTaxYearById(int id)
        => _context.TaxYears.Where(year => year.Id == id).FirstOrDefault();

        IEnumerable<PayRoll> IPayComputationService.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
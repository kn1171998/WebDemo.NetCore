using PayCompute.Entity;
using PayCompute.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) =>
            _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() =>
            _context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        //public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        //=> GetAll().Select(emp => new SelectListItem()
        //{
        //    Text = emp.EmployeeName,
        //    Value = emp.Id.ToString()
        //});

        public IEnumerable<Relative> GetRelatives(int id)
            => _context.Relatives.Where(t => t.EmployeeId == id).Select(t => t);
    }
}
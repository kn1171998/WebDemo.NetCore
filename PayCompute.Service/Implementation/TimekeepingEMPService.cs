using PayCompute.Entity;
using PayCompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayCompute.Service.Implementation
{
    public interface ITimekeepingEMPService : IBaseService<TimekeepingEMP>
    {
        public Array GetData_Flow_Date_Dept(DateTime date, int idDept);

        public List<TimekeepingEMPCreateViewModel> GetListEmployeeDept(int idDept);

        public bool CheckTimeKeeping(DateTime date);
        public IEnumerable<LoadLocationEMP_FlowID> LoadLocationEMP_FlowID(int id);
    }
    public struct TimekeepingEMPCreateViewModel
    {
        public int employeeid { set; get; }
        public string employeename { set; get; }
        public string phone { set; get; }
        public Furloughs furlough { set; get; }
        public bool status { set; get; }
        public string reason { set; get; }
    }
    public struct LoadLocationEMP_FlowID
    {
        public DateTime datejoined { get; set; }
        public string position { set; get; }
        public string location { set; get; }
        public int posID { set; get; }
        public int locaID { set; get; }
    }
    public class TimeKeepingEMPService : RepositoryBaseService<TimekeepingEMP>, ITimekeepingEMPService
    {
        public TimeKeepingEMPService(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<LoadLocationEMP_FlowID> LoadLocationEMP_FlowID(int id)
        {
            var a = (from loca in _context.Locations
                     join locaEmp in _context.LocationEmployees
                     on loca.Id equals locaEmp.LocationId
                     join pos in _context.PositionJobs
                     on loca.PositionJobId equals pos.Id
                     where locaEmp.EmployeeId == id &&
                     loca.Status == true && pos.Status == true &&
                     locaEmp.Status == true && locaEmp.StatusJoindLocation == true
                     select new LoadLocationEMP_FlowID
                     {
                         datejoined = locaEmp.DateJoinedLocation,
                         position = pos.PositionJobName,
                         location = loca.LocationName,
                         posID = pos.Id,
                         locaID = loca.Id
                     });
            return a;
        }
        public bool CheckTimeKeeping(DateTime date)
        {
            return _context.TimekeepingEMPs.Where(t => t.DateTimeKeeping == date).Select(t => t).Count() > 0 ? true : false;
        }

        public List<TimekeepingEMPCreateViewModel> GetListEmployeeDept(int idDept)
        {
            var a = (from loca in _context.Locations
                     join locaEmp in _context.LocationEmployees
                     on loca.Id equals locaEmp.LocationId
                     join emp in _context.Employees
                     on locaEmp.EmployeeId equals emp.Id
                     where loca.DepartmentId == idDept
                     select new TimekeepingEMPCreateViewModel
                     {
                         employeeid = locaEmp.EmployeeId,
                         employeename = emp.EmployeeName,
                         phone = emp.Phone
                     }).ToList();

            return a;
        }

        public Array GetData_Flow_Date_Dept(DateTime date, int idDept)
        {
            var ds = _context.TimekeepingEMPs
                              .Join(_context.Employees,
                              timeEMP => timeEMP.EmployeeId,
                              emp => emp.Id,
                              (timeEMP, emp) => new { TimeEMP = timeEMP, Emp = emp })
                              .Where(t => t.TimeEMP.DateTimeKeeping == date).Select(t => t).ToArray();
            var lsEmpFilter = GetListEmployeeDept(idDept);
            var dm = (from i in ds
                      join l in lsEmpFilter
                      on i.Emp.Id equals l.employeeid
                      select ds).ToArray();
            return dm;
        }
    }
}
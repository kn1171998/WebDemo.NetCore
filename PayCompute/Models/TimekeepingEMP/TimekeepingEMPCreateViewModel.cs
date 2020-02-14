using PayCompute.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Models.TimekeepingEMP
{
    public class TimekeepingEMPCreateViewModel
    {
        public int employeeId { set; get; }
        public string employeename { set; get; }
        public string phone { set; get; }
        public Furloughs furlough { set; get; }
        public bool status { set; get; }
        public string reason { set; get; }
    }
}

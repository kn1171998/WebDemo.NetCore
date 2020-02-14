using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCompute.Entity
{
    public class TimekeepingEMP
    {
        public int Id { set; get; }
        [DataType(DataType.Date)]
        public DateTime DateTimeKeeping { set; get; }
        [DataType(DataType.Time)]
        public TimeSpan StartTimeKeeping { set; get; }
        [DataType(DataType.Time)]
        public TimeSpan EndTimeKeeping { set; get; }
        public string Reason { set; get; }
        public bool Furlough { set; get; }
        public bool Status { set; get; }
        [ForeignKey("Employee")]
        public int EmployeeId { set; get; }
        public Employee Employee { set; get; }
    }
}

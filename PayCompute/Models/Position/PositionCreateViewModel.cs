using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Models.Position
{
    public class PositionCreateViewModel
    {
        public int Id { set; get; }
        [Required, StringLength(50)]
        public string PositionJobCode { set; get; }
        [Required, MaxLength(250)]
        public string PositionJobName { set; get; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InsuranceMoney { set; get; }
        public bool Status { set; get; }
    }
}

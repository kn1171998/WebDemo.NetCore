using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCompute.Models.Position
{
    public class PositionEditViewModel
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
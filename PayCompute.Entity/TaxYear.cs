using System.ComponentModel.DataAnnotations;

namespace PayCompute.Entity
{
    public class TaxYear
    {
        public int Id { set; get; }

        [Required, MaxLength(5)]
        public string YearOfTax { set; get; }
    }
}
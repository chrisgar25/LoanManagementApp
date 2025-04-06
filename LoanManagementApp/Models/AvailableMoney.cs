using System.ComponentModel.DataAnnotations;

namespace LoanManagementApp.Models
{
    public class AvailableMoney
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto no puede ser negativo")]
        public decimal Amount { get; set; }
    }
}
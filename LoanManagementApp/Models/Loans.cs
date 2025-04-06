using System.ComponentModel.DataAnnotations;

namespace LoanManagementApp.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal Amount { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsOverdue { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
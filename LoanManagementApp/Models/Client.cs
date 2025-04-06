using System.ComponentModel.DataAnnotations;

namespace LoanManagementApp.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
using System.ComponentModel.DataAnnotations;

namespace FinistSoftWebApi.Models
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        public Contract Sender { get; set; } = null!;
        [Required]
        public int ReciverId { get; set; }
        public Contract Reciver { get; set; } = null!;
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }

    }
}

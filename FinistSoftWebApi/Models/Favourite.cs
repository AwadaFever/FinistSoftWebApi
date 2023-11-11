using System.ComponentModel.DataAnnotations;

namespace FinistSoftWebApi.Models
{
    public class Favourite
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public int TransactionId { get; set; }
        public TransactionHistory Transaction { get; set; } = null!;

    }
}

using System.ComponentModel.DataAnnotations;

namespace FinistSoftWebApi.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [MaxLength(20)]
        public string Number { get; set; }
        [Required]
        public DateTime DateOpen { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public decimal Amount { get; set; }

    }
}

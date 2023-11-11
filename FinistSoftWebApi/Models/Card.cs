using System.ComponentModel.DataAnnotations;

namespace FinistSoftWebApi.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateOpen { get; set; }
        [Required]
        public DateTime DateClosed { get; set; }
        [Required]
        public int ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        [Required]
        public string Number { get; set; }
        [Required]
        public string CVV { get; set; }
        public string Image { get; set; }

    }

}

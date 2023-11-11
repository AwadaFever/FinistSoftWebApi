using System.ComponentModel.DataAnnotations;

namespace FinistSoftWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(30)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Patronymic { get; set; } = string.Empty;
        [Required]
        public DateTime Birthday { get; set; }

    }
}

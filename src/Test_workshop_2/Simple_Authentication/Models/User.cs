using System.ComponentModel.DataAnnotations;

namespace Simple_Authentication.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
    }
}

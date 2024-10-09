namespace Average_Authentication.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string Role { get; set; } = "User";  // Добавим роль (например, "Admin", "User")
    }
}

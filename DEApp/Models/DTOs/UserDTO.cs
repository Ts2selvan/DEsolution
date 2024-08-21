namespace DEApp.Models.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public int ? RoleId { get; set; }

    }
}

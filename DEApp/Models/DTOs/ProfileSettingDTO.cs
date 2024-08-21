namespace DEApp.Models.DTOs
{
    public class ProfileSettingDTO
    {
        public int ProfileSettingId { get; set; }

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;

        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DEApp.Models;

public partial class ProfileSetting
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}

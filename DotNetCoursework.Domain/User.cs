using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class User
{
    public long Id { get; set; }

    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Stylist? Stylist { get; set; }

    public bool IsInRole(Role role)
    {
        return Role.Name==role.Name;
    }

}

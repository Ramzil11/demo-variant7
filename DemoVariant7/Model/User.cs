using System;
using System.Collections.Generic;

namespace DemoVariant7.Model;

public partial class User
{
    public int UserId { get; set; }

    public string UserSurname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserPatronymic { get; set; } = null!;

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public int? UserRole { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? UserRoleNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Account
{
    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }
    public short AccountType { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Role Role { get; set; } = null!;
}

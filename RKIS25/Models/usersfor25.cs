using System;
using System.Collections.Generic;

namespace context.Models;

public partial class usersfor25
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Birthdate { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IdRole { get; set; }

    public virtual Rolesfor25? IdRoleNavigation { get; set; }
}

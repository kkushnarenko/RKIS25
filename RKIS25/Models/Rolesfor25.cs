using System;
using System.Collections.Generic;


namespace context.Models;

public partial class Rolesfor25
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<usersfor25> Usersfor25s { get; } = new List<usersfor25>();
}

using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class PermissionGroup
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<GroupRight> GroupRights { get; set; } = new List<GroupRight>();
}

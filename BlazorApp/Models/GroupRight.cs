using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class GroupRight
{
    public int Id { get; set; }

    public int PermissionGroupsId { get; set; }

    public string? Area { get; set; }

    public virtual PermissionGroup PermissionGroups { get; set; } = null!;
}

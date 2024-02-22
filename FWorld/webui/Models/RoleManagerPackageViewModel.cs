using Microsoft.AspNetCore.Identity;

namespace webui.Models;

public class RoleManagerPackageViewModel
{
    public RoleViewModel? RoleViewModel { get; set; }
    public IEnumerable<IdentityRole>? RoleList { get; set; }
}

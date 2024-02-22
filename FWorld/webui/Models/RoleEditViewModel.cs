using Microsoft.AspNetCore.Identity;
using webui.Identity;

namespace webui.Models;
public class RoleEditViewModel
{
    public IdentityRole? Role{get;set;}
    public IEnumerable<User>? Members { get; set; }
    public IEnumerable<User>? NonMembers { get; set; }

}
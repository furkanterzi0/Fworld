using Microsoft.AspNetCore.Identity;

namespace webui.Identity;

public class User:IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime? DateOfRegister{get;set;}
}

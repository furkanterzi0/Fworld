using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using webui.Identity;

namespace webui.Models;

public class RoleViewModel
{
    [Required]
    public string? Name { get; set; }
}


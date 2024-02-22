using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using webui.Identity;
using webui.Models;
namespace webui.Controllers;

[Authorize(Roles ="Admin")]
public class AdminController:Controller
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager; //cookie icin
    private RoleManager<IdentityRole> _roleManager;
    public AdminController(UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager)
    {
        _userManager=userManager;
        _signInManager=signInManager;
        _roleManager=roleManager;
    }

    public IActionResult Page(){
        
        return View();
    }
    public IActionResult UserList(){
        var users=_userManager.Users.ToList();
        ViewBag.UserCount=_userManager.Users.Count();
        return View(users);
    }
    public async Task<IActionResult> UserDelete(string id){
        var user=  await _userManager.FindByIdAsync(id);
        
        if(user!=null){
            await _userManager.DeleteAsync(user);
        }
        
        return RedirectToAction("UserList");
    }
    public IActionResult RoleManager(){
        var PackageViewModel= new RoleManagerPackageViewModel{
            RoleList=_roleManager.Roles
        };
        
        return View(PackageViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> RoleManager(RoleManagerPackageViewModel PackageViewModel)
    {
        PackageViewModel.RoleList=_roleManager.Roles;
        

        if (ModelState.IsValid)
        {
            
            var result = await _roleManager.CreateAsync(new IdentityRole(PackageViewModel.RoleViewModel?.Name ?? "null"));
            if (result.Succeeded)
            {
                return View(PackageViewModel);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ViewBag.Errors = error.Description;
                }
            }
        }

        return View(PackageViewModel);
    }
    public async Task<IActionResult> RoleDelete(string id){

        await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id));
        return RedirectToAction("RoleManager");
    }
    public async Task<IActionResult> RoleEdit(string id){

        var role = await _roleManager.FindByIdAsync(id);

        var members = new List<User>();
        var nonmembers = new List<User>();

        foreach(var user in _userManager.Users)
        {
            var list= (await _userManager.IsInRoleAsync(user,role?.Name??"")) ? members : nonmembers; //list referans 

            list.Add(user); //burada yukaridaki kosula göre listin referansini alip o liste ekliyor

        }
        var model = new RoleEditViewModel()
        {
            Role=role,
            Members=members,
            NonMembers=nonmembers
        };

        return View(model);
    }
    

}

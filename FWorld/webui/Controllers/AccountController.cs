using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using webui.Identity;
using webui.Models;

namespace webui.Controllers
{
    public class AccountController:Controller
    {
        
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager; //cookie icin
        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginViewModel{
                returnUrl=returnUrl
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken] //formda olusan tokeni kontrol etmek crsf

        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            var user= await _userManager.FindByNameAsync(model.username??"");
            if(user==null){
                ViewBag.UsernameException="invalid username";
                return View(model);
            }
            if(!await _userManager.IsEmailConfirmedAsync(user)){
                ViewBag.LoginException="account not confirmed";
                return View(model);
            }

            var result= await _signInManager.PasswordSignInAsync(user,model.password??"",true,false);

            if(result.Succeeded){

                return Redirect(model.returnUrl ?? $"/Account/Page/{user.Id}");

            }
            ViewBag.LoginException="incorrect password";

            return View(model);
        }

        public async Task<IActionResult>Logout(){
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }


        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //formda olusan tokeni kontrol etmek
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                Name  = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email,
                DateOfRegister=DateTime.Now    
            };           

            var result = await _userManager.CreateAsync(user,model.Password??"");
            if(result.Succeeded)
            {

                // generate token
                var token= await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var url = Url.Action("ConfirmEmail","Account",new{
                    userId=user.Id,
                    token=token
                });

                System.Console.WriteLine(url);
                TempData["url"]=url;

                await _userManager.AddToRoleAsync(user,"User");
                
                return RedirectToAction("Login","Account");
            }
            foreach (var error in result.Errors)
            {
                ViewBag.PasswordException=error.Description;
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Page(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user != null){

                DateTime dt = user.DateOfRegister ?? DateTime.Now;
                TimeSpan timeSinceRegistration = DateTime.Now - dt; //!!!!!!!!!
                ViewBag.DtDay = timeSinceRegistration.Days;
                ViewBag.DtHour = timeSinceRegistration.Hours;

                return View(user);
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {   
            var user = await _userManager.FindByIdAsync(id);

            return View(user);
        }
        public async Task<IActionResult> ConfirmEmail(string userId,string token){
            if(userId==null || token==null){
                TempData["message"]="gecersiz token";
                return View();
            }
            
            var user = await _userManager.FindByIdAsync(userId);

            if(user==null){
                TempData["message"]="hesap onaylanmadi";
                return View();
            }
            var result = await _userManager.ConfirmEmailAsync(user,token);
            if(result.Succeeded){
                TempData["message"]="hesap onaylandı";
                return View();
            }
            return View();
        }
        public IActionResult Accsesdenied(){
            return View();
        }

    }
}
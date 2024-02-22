using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webui.Controllers;
[Authorize]
public class ArcadeController:Controller
{
    public  IActionResult Game_A (){
            return View();
    }
    public  IActionResult Game_B (){
        return View();
    }
}

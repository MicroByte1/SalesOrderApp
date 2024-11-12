


using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller {
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;
    private readonly RoleManager<IdentityRole<int>> roleManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Register(){
        return View();
    }

     [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel){
        var res = await userManager.FindByNameAsync(registerViewModel.UserName);
        if (res == null){
            AppUser appUser = new AppUser{
                UserName = registerViewModel.UserName,
                Location = registerViewModel.Location,
                Name = registerViewModel.Name,
                Picture = new byte[2]
            };
            var res2 = await userManager.CreateAsync(appUser, registerViewModel.Password);
            if (res2.Succeeded){
                /*res2 = await userManager.AddToRoleAsync(appUser, "NewCustomer");
                if (!res2.Succeeded)
                    return Content("Error While Adding To Role");*/
                return Content("Account Register Sucessfully");
            }
            else{
                return View(registerViewModel);
            }
        }
        return Content("Account Already Exist Here");
    }

    [HttpGet]
    public IActionResult Login(){
        return View();
    }

     [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel){
        var _user = await userManager.FindByNameAsync(loginViewModel.UserName);
        if (_user != null){
            var res = await userManager.CheckPasswordAsync(_user, loginViewModel.Password);
            if (res){
                await signInManager.SignInAsync(_user, loginViewModel.RememberMe);
                return RedirectToAction("Index", "Products");
            }
        }
        return View(loginViewModel);
    }

    public async Task<IActionResult> Logout(){
        await signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
    
    
    
    public IActionResult getid(){
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Content(id);
    }

    public async Task<IActionResult> Profile(){
        var user = await userManager.FindByNameAsync(User.Identity.Name);
        var profileView = new ProfileViewModel(user);
        return View(profileView);
    }
    [HttpPost]
    public async Task<IActionResult> Profile(ProfileViewModel viewModel, IFormFile ProfilePic){
        var user = await userManager.FindByNameAsync(User.Identity.Name);
        if (ProfilePic != null){
            using(var stream = new MemoryStream()){
                await ProfilePic.CopyToAsync(stream);
                user.Picture = stream.ToArray();
            }
        }else{
            return Content("img is null");
        }
        user.Name = viewModel.Name;
        user.Location = viewModel.Location;
        await userManager.UpdateAsync(user);
        return RedirectToAction("Profile");
    }
}
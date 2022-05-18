using IMDB.Data;
using IMDB.Data.services;
using IMDB.Data.Static;
using IMDB.Data.ViewModels;
using IMDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    public class AccountController : Controller
    {

        //to work with user data
        private readonly UserManager<ApplicationUser> _userManager;

        //to check if the user signed
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }



       
        public IActionResult Register()
        {
           

            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

           

            var newAppUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                UserName = registerVM.EmailAddress,
                Email = registerVM.EmailAddress,
                EmailConfirmed = true,
                profilepicURL = registerVM.ImageURL,
                age = registerVM.age

            };
            var newUserResponse = await _userManager.CreateAsync(newAppUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newAppUser, UserRoles.User);


            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }



    }
}

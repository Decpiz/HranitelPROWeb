using HranitelPROWeb.Data;
using HranitelPROWeb.Data.Entities;
using HranitelPROWeb.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HranitelPROWeb.Controllers
{
    public class UserController : Controller
    {
        HranitelDBContext _dbContext;

        [BindProperty]
        public LoginViewModel Model { get; set; }

        public UserController(HranitelDBContext dbContext, SignInManager<IdentityUser> signInManager)
        {
            _dbContext = dbContext;
        }



        public async Task<IActionResult> Profile()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _dbContext.Polzovatelis
                .FirstOrDefaultAsync(u => u.Login == model.LoginUser && u.Parol == model.Password);

            if (user is null)
            {
                ViewBag.Error = "Некорректные логин и(или) пароль";
            }

            await AuthenticateAsync(user);
            return RedirectToAction("Navigate", "RegApplication");
        }

        public async Task<IActionResult> Registration()
        {
            return View();
        }

        public async Task AuthenticateAsync(Polzovateli user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdPolzovatelia.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}

using HranitelPROWeb.Data;
using HranitelPROWeb.Data.Entities;
using HranitelPROWeb.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HranitelPROWeb.Controllers
{
    public class AuthController : Controller
    {
        HranitelDBContext _dbContext;

        public AuthController(HranitelDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var user = await _dbContext.Polzovatelis.FirstOrDefaultAsync(u => u.Login == model.LoginUser
                && u.Parol == model.Password);

            if(user != null)
            {
                await AuthenticateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        public async Task<IActionResult> Registration()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public async Task AuthenticateAsync(Polzovateli user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdPolzovatelia.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
               ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}

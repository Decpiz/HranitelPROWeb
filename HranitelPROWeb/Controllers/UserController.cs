using HranitelPROWeb.Data;
using Microsoft.AspNetCore.Mvc;
using HranitelPROWeb.Models.User;
using HranitelPROWeb.Data.Entities;
using System.Security.Claims;
using HranitelPROWeb.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace HranitelPROWeb.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly HranitelDBContext _context;

        private ProfileViewModel profileVM = new ProfileViewModel
        {
            Applications = new List<Zajavki>(),
            CurrentUser = new Polzovateli()
        };

        public UserController(HranitelDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var appliRepository = new ZajavkiRepository(_context);
            var userRepository = new UsersRepository(_context);

            profileVM.CurrentUser = await userRepository.GetByLogin(HttpContext.User.Identity.Name);
            profileVM.Applications = await appliRepository.GetByCurUser(profileVM.CurrentUser);
            await appliRepository.LoadConnections(profileVM.Applications);

            return View(profileVM);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {


            return View(profileVM);
        }
    }
}

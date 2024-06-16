using HranitelPROWeb.Data;
using Microsoft.AspNetCore.Mvc;
using HranitelPROWeb.Models.User;
using HranitelPROWeb.Data.Entities;
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

        public async Task<IActionResult> Index()
        {
            profileVM.Appli = _context.Zajavkis.FirstOrDefault();

            var appliRepository = new ZajavkiRepository(_context);
            var userRepository = new UsersRepository(_context);

            profileVM.CurrentUser = await userRepository.GetByLogin(HttpContext.User.Identity.Name);
            profileVM.Applications = await appliRepository.GetByCurUser(profileVM.CurrentUser);
            await appliRepository.LoadConnections(profileVM.Applications);

            return View(profileVM);

        }

        public async Task<IActionResult> History([Bind(Prefix ="history")] ProfileViewModel model)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> History()
        {
            return View(profileVM);
        }

        public async Task<IActionResult> Profile([Bind(Prefix ="profile")] ProfileViewModel model)
        {
            return View(profileVM);
        }

        public async Task<IActionResult> EditProfile()
        {
            var userRepository = new UsersRepository(_context);
            profileVM.CurrentUser = await userRepository.GetByLogin(HttpContext.User.Identity.Name);

            profileVM.LastName = profileVM.CurrentUser.Familia;
            profileVM.Name = profileVM.CurrentUser.Imya;
            profileVM.Patronomic = profileVM.CurrentUser.Otchestvo;
            profileVM.Email = profileVM.CurrentUser.Email;

            return View(profileVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userRepository = new UsersRepository(_context);
                var curUser = await userRepository.GetByLogin(HttpContext.User.Identity.Name);
                await userRepository.Update(curUser, model.LastName, model.Name, model.Email, model.Patronomic);

                return RedirectToAction("Index", "User");
            }
            return View(model);
        }

    }
}

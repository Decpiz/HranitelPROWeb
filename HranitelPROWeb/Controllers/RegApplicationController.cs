using HranitelPROWeb.Data;
using HranitelPROWeb.Data.Entities;
using HranitelPROWeb.Data.Repositories;
using HranitelPROWeb.Models.RegApplications;
using Microsoft.AspNetCore.Mvc;

namespace HranitelPROWeb.Controllers
{
    public class RegApplicationController : Controller
    {
        private readonly HranitelDBContext _dbContext;

        private static GroupStepTwoViewModel regViewModel = new GroupStepTwoViewModel();
        private static GroupStepOneViewModel privacyViewModel = new GroupStepOneViewModel
        {
            Visitors = new List<Posetiteli>()
        };

        public RegApplicationController(HranitelDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IActionResult Navigate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GroupStepOne(GroupStepOneViewModel model)
        {
            //ПРОВЕРКА ДАТЫ\\
            if (DateTime.Now.Date.Year - model.DateBirthday.Date.Year < 14)
            { ModelState.AddModelError(nameof(model.DateBirthday), "Возраст гостей - от 14 лет"); }

            else if (DateTime.Now.Date.Year - model.DateBirthday.Date.Year == 14)
            {
                if (DateTime.Now.Date.Month < model.DateBirthday.Date.Month)
                { ModelState.AddModelError(nameof(model.DateBirthday), "Возраст гостей - от 14 лет"); }

                else if (DateTime.Now.Date.Month == model.DateBirthday.Date.Month)
                {
                    if (DateTime.Now.Date.Day < model.DateBirthday.Date.Day)
                    { ModelState.AddModelError(nameof(model.DateBirthday), "Возраст гостей - от 14 лет"); }
                }
            }

            if (DateTime.Now.Date.Year - model.DateBirthday.Date.Year > 100)
            { ModelState.AddModelError(nameof(model.DateBirthday), "Вам не может быть более 100 лет"); }
            //ПРОВЕРКА ДАТЫ\\

            //ПРОВЕРКА НА ЧС\\
            if (ModelState.IsValid)
            {
                foreach (var csV in _dbContext.CherniySpisoks)
                {
                    if (model.PasSeries == csV.SeriaPas && model.PasNumber == csV.NomerPas)
                    {
                        ModelState.AddModelError(nameof(model.Error),
                        csV.Familia + " "
                        + csV.Imya + " "
                        + csV.Otchestvo + " Находится в черном списке");
                    }
                }
            }
            //ПРОВЕРКА НА ЧС\\

            if (ModelState.IsValid)
            {
                var visitor = new Posetiteli
                {
                    SeriaPas = model.PasSeries,
                    NomerPas = model.PasNumber,
                    Familia = model.FirstName,
                    Imya = model.Name,
                    Otchestvo = model.Patronomic,
                    NomerTelefona = model.PhoneNumber,
                    DataRozhdenia = model.DateBirthday
                };

                privacyViewModel.Visitors.Add(visitor);
            }

            return View(privacyViewModel);
        }

        public IActionResult GroupStepOne()
        {
            return View(privacyViewModel);
        }

        public async Task<IActionResult> GroupStepTwo()
        {
            PodrazdeleniaRepository podrazdeleniaRepository = new PodrazdeleniaRepository(_dbContext);
            CeliRepository celiRepository = new CeliRepository(_dbContext);

            regViewModel.Visitors = privacyViewModel.Visitors;
            regViewModel.Divisions = podrazdeleniaRepository.Get();
            regViewModel.Targets = celiRepository.Get();

            return View(regViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GroupStepTwo(GroupStepTwoViewModel model)
        {


            //Проверка количества гостей\\
            if (ModelState.IsValid)
            {
                if (regViewModel.Visitors.Count < 5)
                { ModelState.AddModelError(nameof(model.CountError), "В груповой заявке должно быть минимум 5 гостей"); }
            }
            //Проверка количества гостей\\

            //Проверка даты\\ - "систематическая"
            if (model.DateRegistration < DateTime.Now)
            { ModelState.AddModelError(nameof(model.DateRegistration), "Выбранная дата - прошлое"); }
            //Проверка даты\\

            if (ModelState.IsValid)
            {
                //var groupRepository = new GroupRepository(_dbContext);
                var visitorRepository = new PosetiteliRepository(_dbContext);
                var appliRepository = new ZajavkiRepository(_dbContext);

                await appliRepository.Add(1,
                    int.Parse(model.SelectDivision.Split(' ')[0]),
                    int.Parse(model.SelectTarget.Split(' ')[0]),
                    model.DateRegistration);

                var appli = await appliRepository.GetLast();

                await visitorRepository.AddList(appli, regViewModel.Visitors);


            }

            return View(regViewModel);
        }
    }
}

using HranitelPROWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HranitelPROWeb.Data.Repositories
{
    public class ZajavkiRepository
    {
        private readonly HranitelDBContext _context;

        public ZajavkiRepository(HranitelDBContext context)
        {
            _context = context;
        }

        public async Task Add(int userId, int divisionId, int targetId, DateTime dateVisit)
        {

            string numberToApplication = AutoGenerateNumber();
            foreach (Zajavki z in _context.Zajavkis.ToList())
            {
                while (z.NomerZajavki == numberToApplication)
                {
                    numberToApplication = AutoGenerateNumber();
                    break;
                }
            }

            var application = new Zajavki
            {
                NomerZajavki = numberToApplication,
                IdPolzovatelia = userId,
                IdPodrazdelenia = divisionId,
                IdCeli = targetId,
                IdStatusa = 3,
                DataOformlenia = DateTime.Now,
                DataPoseshenia = dateVisit
            };

            await _context.Zajavkis.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task<Zajavki> GetLast()
        {
            return await _context.Zajavkis
                .OrderBy(x=>x.IdZajavki)
                .LastAsync();
        }

        public async Task<List<Zajavki>> GetByCurUser(Polzovateli curUser)
        {
            var applications = new List<Zajavki>();
            foreach (var appli in _context.Zajavkis)
            {
                if(appli.IdPolzovatelia == curUser.IdPolzovatelia)
                {
                    applications.Add(appli);
                }
            }

            return applications;
        }

        public async Task LoadConnections(List<Zajavki> appliNotConn)
        {
            foreach (var appli in appliNotConn)
            {
                //Связь со статусом\\
                var status = _context.Statusis.FirstOrDefault(s => s.IdStatusa == appli.IdStatusa);
                appli.IdStatusaNavigation.Nazvanie = status.Nazvanie;
                appli.IdStatusaNavigation.Color = status.Color;
                //Связь со статусом\\

                //Связь с подразделениями\\
                var division = _context.Podrazdelenia.FirstOrDefault(d => d.IdPodrazdelenia == appli.IdPodrazdelenia);
                appli.IdPodrazdeleniaNavigation.NazvanieGoroda = division.NazvanieGoroda;
                appli.IdPodrazdeleniaNavigation.NazvanieYlici = division.NazvanieYlici;
                appli.IdPodrazdeleniaNavigation.NomerStroenia = division.NomerStroenia;
                //Связь с подразделениями\\

                var group = _context.GrupZajavkis.Where(g => g.IdZajavki == appli.IdZajavki).ToList();
                appli.GrupZajavkis = group;

                int a = 5;
            }
        }

        public async Task<List<Posetiteli>> GetVisitors(Zajavki appli)
        {
            var visitors = new List<Posetiteli>();

            var groupID = _context.GrupZajavkis.Where(g => g.IdZajavki == appli.IdZajavki);
            foreach(var group in groupID)
            {
                var visitor = await _context.Posetitelis.FirstOrDefaultAsync(v => v.IdPsetitelia == group.IdPosetitelia);

                visitors.Add(visitor);
            }

            return visitors;
        }

        public string AutoGenerateNumber()
        {
            string[] alphavit = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

            string number = "GR-";
            Random rnd = new Random();

            while (number.Length < 12)
            {
                if (rnd.Next(4) == 0)
                { number += alphavit[rnd.Next(alphavit.Length)]; }
                else
                { number += rnd.Next(10); }
            }

            return number;
        }
    }
}

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

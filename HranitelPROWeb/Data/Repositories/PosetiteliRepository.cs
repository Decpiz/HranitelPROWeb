using HranitelPROWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HranitelPROWeb.Data.Repositories
{
    public class PosetiteliRepository
    {
        private readonly HranitelDBContext _context;

        public PosetiteliRepository(HranitelDBContext context)
        {
            _context = context;
        }

        public async Task Add(string lastName, string firstName, string patronomic, 
            string pasSeries, string pasNumber, string phoneNumber, string eMail, DateTime dateBirthday)
        {
            var visitor = new Posetiteli
            {
                Familia = lastName,
                Imya = firstName,
                Otchestvo = patronomic,
                SeriaPas = pasSeries,
                NomerPas = pasNumber,
                NomerTelefona = phoneNumber,
                Email = eMail,
                DataRozhdenia = dateBirthday
            };

            await _context.Posetitelis.AddAsync(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task AddList(Zajavki appli, List<Posetiteli> visitors)
        {
            await _context.Posetitelis.AddRangeAsync(visitors);
            await _context.SaveChangesAsync();

            for (int i = 0; i < visitors.Count; i++)
            {
               appli.GrupZajavkis.Add(new GrupZajavki { IdPosetitelia = visitors[i].IdPsetitelia });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Posetiteli>> GetLasts(int quality)
        {
            var visitors = _context.Posetitelis
                .OrderBy(x => x.IdPsetitelia)
                .TakeLast(quality)
                .ToListAsync();

            return await visitors;
        }
    }
}

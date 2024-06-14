using HranitelPROWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HranitelPROWeb.Data.Repositories
{
    public class PodrazdeleniaRepository
    {
        private readonly HranitelDBContext _context;
        public PodrazdeleniaRepository(HranitelDBContext context)
        {
            _context = context;
        }

        public List<Podrazdelenium> Get()
        {
            return _context.Podrazdelenia
                .AsNoTracking()
                .OrderBy(city => city.NazvanieGoroda)
                .ToList();
        }
    }
}

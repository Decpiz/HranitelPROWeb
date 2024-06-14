using HranitelPROWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HranitelPROWeb.Data.Repositories
{
    public class CeliRepository
    {
        private readonly HranitelDBContext _context;
        public CeliRepository(HranitelDBContext context)
        {
            _context = context;
        }

        public List<Celi> Get()
        {
            return _context.Celis
                .AsNoTracking()
                .ToList();

        }
    }
}

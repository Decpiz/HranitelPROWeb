using HranitelPROWeb.Data.Entities;

namespace HranitelPROWeb.Data.Repositories
{
    public class GroupRepository
    {
        private readonly HranitelDBContext _context;

        public GroupRepository(HranitelDBContext context)
        {
            _context = context;
        }

        public async Task AddGroupApplication(Zajavki appli, List<Posetiteli> visitors)
        {
            for (int i = 0; i < visitors.Count; i++)
            {
                var group = new GrupZajavki
                {
                    IdZajavki = appli.IdZajavki,
                    IdPosetitelia = visitors[i].IdPsetitelia
                };
                await _context.AddAsync(group);
            }
            await _context.SaveChangesAsync();
        }
    }
}

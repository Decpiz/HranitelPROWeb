using HranitelPROWeb.Data.Entities;

namespace HranitelPROWeb.Models.User
{
    public class ProfileViewModel
    {
        public List<Zajavki>? Applications { get; set; }
        public Polzovateli? CurrentUser { get; set; }
        public Posetiteli? Visitors { get; set; }
    }
}

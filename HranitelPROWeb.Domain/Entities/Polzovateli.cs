using System;
using System.Collections.Generic;

namespace HranitelPRO;

public partial class Polzovateli
{
    public int IdPolzovatelia { get; set; }

    public string Familia { get; set; } = null!;

    public string Imya { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Parol { get; set; } = null!;

    public int? IdOrganizacii { get; set; }

    public byte[]? Photo { get; set; }

    public string? Status { get; set; }

    public virtual Organizacii? IdOrganizaciiNavigation { get; set; }

    public virtual ICollection<Zajavki> Zajavkis { get; set; } = new List<Zajavki>();
}

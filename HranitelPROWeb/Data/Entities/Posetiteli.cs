using System;
using System.Collections.Generic;

namespace HranitelPROWeb.Data.Entities;

public partial class Posetiteli
{
    public int IdPsetitelia { get; set; }

    public string SeriaPas { get; set; } = null!;

    public string NomerPas { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string Imya { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public string NomerTelefona { get; set; } = null!;

    public string? Email { get; set; }

    public string? NazvanieOrganizacii { get; set; }

    public DateTime DataRozhdenia { get; set; }

    public virtual ICollection<GrupZajavki> GrupZajavkis { get; set; } = new List<GrupZajavki>();
}

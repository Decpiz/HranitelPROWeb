using System;
using System.Collections.Generic;

namespace HranitelPROWeb.Data.Entities;

public partial class Organizacii
{
    public int IdOrganizacii { get; set; }

    public string Nazvanie { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string GenDirFio { get; set; } = null!;

    public string Ogrn { get; set; } = null!;

    public virtual ICollection<Polzovateli> Polzovatelis { get; set; } = new List<Polzovateli>();
}

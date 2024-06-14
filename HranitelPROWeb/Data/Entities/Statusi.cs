using System;
using System.Collections.Generic;

namespace HranitelPROWeb.Data.Entities;

public partial class Statusi
{
    public int IdStatusa { get; set; }

    public string Nazvanie { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<Zajavki> Zajavkis { get; set; } = new List<Zajavki>();
}

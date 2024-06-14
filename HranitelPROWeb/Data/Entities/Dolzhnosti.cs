using System;
using System.Collections.Generic;

namespace HranitelPROWeb.Data.Entities;

public partial class Dolzhnosti
{
    public int IdDolzhnosti { get; set; }

    public string Nazvanie { get; set; } = null!;

    public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; } = new List<Sotrudniki>();
}

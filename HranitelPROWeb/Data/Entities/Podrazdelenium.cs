using System;
using System.Collections.Generic;

namespace HranitelPROWeb.Data.Entities;

public partial class Podrazdelenium
{
    public int IdPodrazdelenia { get; set; }

    public string NazvanieGoroda { get; set; } = null!;

    public string NazvanieYlici { get; set; } = null!;

    public int NomerStroenia { get; set; }

    public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; } = new List<Sotrudniki>();

    public virtual ICollection<Zajavki> Zajavkis { get; set; } = new List<Zajavki>();
}

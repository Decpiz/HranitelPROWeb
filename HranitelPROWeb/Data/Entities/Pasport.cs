using System;
using System.Collections.Generic;

namespace HranitelPROWeb.Data.Entities;

public partial class Pasport
{
    public int IdPasporta { get; set; }

    public string Seria { get; set; } = null!;

    public string Nomer { get; set; } = null!;

    public DateTime DataVidachi { get; set; }

    public string KodPodrazdelenia { get; set; } = null!;
}

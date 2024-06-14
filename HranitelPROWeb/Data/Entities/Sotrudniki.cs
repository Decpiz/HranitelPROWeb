using System;
using System.Collections.Generic;

namespace HranitelPROWeb.Data.Entities;

public partial class Sotrudniki
{
    public int IdSotrudnika { get; set; }

    public int IdDolzhnosti { get; set; }

    public int? IdPodrazdelenia { get; set; }

    public string Familia { get; set; } = null!;

    public string Imya { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public string SeriaPas { get; set; } = null!;

    public string NomerPas { get; set; } = null!;

    public string KodAvtorizacii { get; set; } = null!;

    public virtual Dolzhnosti IdDolzhnostiNavigation { get; set; } = null!;

    public virtual Podrazdelenium? IdPodrazdeleniaNavigation { get; set; }
}

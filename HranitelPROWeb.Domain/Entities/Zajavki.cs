using System;
using System.Collections.Generic;

namespace HranitelPRO;

public partial class Zajavki
{
    public int IdZajavki { get; set; }

    public string NomerZajavki { get; set; } = null!;

    public int IdPolzovatelia { get; set; }

    public int IdPodrazdelenia { get; set; }

    public DateTime DataPoseshenia { get; set; }

    public DateTime? DataOformlenia { get; set; }

    public int IdCeli { get; set; }

    public int IdStatusa { get; set; }

    public string? Soobshenie { get; set; }

    public virtual ICollection<GrupZajavki> GrupZajavkis { get; set; } = new List<GrupZajavki>();

    public virtual Celi IdCeliNavigation { get; set; } = null!;

    public virtual Podrazdelenium IdPodrazdeleniaNavigation { get; set; } = null!;

    public virtual Polzovateli IdPolzovateliaNavigation { get; set; } = null!;

    public virtual Statusi IdStatusaNavigation { get; set; } = null!;
}

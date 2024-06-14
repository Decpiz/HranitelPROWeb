using System;
using System.Collections.Generic;

namespace HranitelPRO;

public partial class GrupZajavki
{
    public int IdZajavki { get; set; }

    public int IdPosetitelia { get; set; }

    public string? A1 { get; set; }

    public virtual Posetiteli IdPosetiteliaNavigation { get; set; } = null!;

    public virtual Zajavki IdZajavkiNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace HranitelPRO;

public partial class Celi
{
    public int IdCeli { get; set; }

    public string Tekst { get; set; } = null!;

    public virtual ICollection<Zajavki> Zajavkis { get; set; } = new List<Zajavki>();
}

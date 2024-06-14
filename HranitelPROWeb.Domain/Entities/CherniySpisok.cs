using System;
using System.Collections.Generic;

namespace HranitelPRO;

public partial class CherniySpisok
{
    public int IdCs { get; set; }

    public string SeriaPas { get; set; } = null!;

    public string NomerPas { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string Imya { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public string NomerTelefona { get; set; } = null!;
}

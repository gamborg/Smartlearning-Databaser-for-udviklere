using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Svar
{
    public Guid Id { get; set; }

    public string? Sporgsmaalsnummer { get; set; }

    public int? Svarnummer { get; set; }

    public string? Tekst { get; set; }

    public virtual Sporgsmaal? SporgsmaalsnummerNavigation { get; set; }
}

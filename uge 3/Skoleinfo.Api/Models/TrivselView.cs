using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class TrivselView
{
    public Guid TrivselId { get; set; }

    public int? Institutionsnummer { get; set; }

    public int? Koen { get; set; }

    public decimal? Vaerdi { get; set; }

    public string? SporgsmaalTekst { get; set; }

    public string? SvarTekst { get; set; }
}

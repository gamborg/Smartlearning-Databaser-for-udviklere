using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Trivsel
{
    public Guid Id { get; set; }

    public int? Institutionsnummer { get; set; }

    public string? Sporgsmaalsnummer { get; set; }

    public int? Svarnummer { get; set; }

    public int? Koen { get; set; }

    public decimal? Vaerdi { get; set; }
}

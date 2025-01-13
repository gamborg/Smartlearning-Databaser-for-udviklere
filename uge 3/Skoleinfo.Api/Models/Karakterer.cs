using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Karakterer
{
    public Guid Id { get; set; }

    public int? Institutionsnummer { get; set; }

    public int? Koen { get; set; }

    public string? Skoleaar { get; set; }

    public int? Klassetrin { get; set; }

    public decimal? Gennemsnit { get; set; }
}

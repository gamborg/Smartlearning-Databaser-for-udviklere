using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Institutionsoplysninger
{
    public Guid Id { get; set; }

    public int? Nummer { get; set; }

    public string? Navn { get; set; }

    public string? Adresse { get; set; }

    public string? Postnummer { get; set; }

    public string? Hjemmeside { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public decimal? GeoLaengde { get; set; }

    public decimal? GeoBredde { get; set; }
}

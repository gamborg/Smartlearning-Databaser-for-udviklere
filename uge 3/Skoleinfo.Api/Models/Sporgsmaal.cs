using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Sporgsmaal
{
    public Guid Id { get; set; }

    public string Nummer { get; set; } = null!;

    public string? Tekst { get; set; }

    public virtual ICollection<Svar> Svars { get; set; } = new List<Svar>();

    public virtual ICollection<Trivsel> Trivsels { get; set; } = new List<Trivsel>();
}

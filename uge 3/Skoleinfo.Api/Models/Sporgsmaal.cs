using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Sporgsmaal
{
    public Guid Id { get; set; }

    public string? Nummer { get; set; }

    public string? Tekst { get; set; }
}

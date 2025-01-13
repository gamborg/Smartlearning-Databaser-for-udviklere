using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class InstitutionAvgScore
{
    public int Nummer { get; set; }

    public string Navn { get; set; } = null!;

    public decimal? AverageScore { get; set; }
}

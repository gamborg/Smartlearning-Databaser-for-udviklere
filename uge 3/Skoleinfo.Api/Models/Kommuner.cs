using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Kommuner
{
    public Guid Id { get; set; }

    public int Nummer { get; set; }

    public string Navn { get; set; } = null!;

    public virtual ICollection<Institutioner> Institutioners { get; set; } = new List<Institutioner>();
}

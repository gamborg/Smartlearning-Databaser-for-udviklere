using System;
using System.Collections.Generic;

namespace Skoleinfo.Api.Models;

public partial class Institutioner
{
    public Guid Id { get; set; }

    public int Nummer { get; set; }

    public string Navn { get; set; } = null!;

    public int Kommunenummer { get; set; }

    public virtual ICollection<Karakterer> Karakterers { get; set; } = new List<Karakterer>();

    public virtual Kommuner KommunenummerNavigation { get; set; } = null!;
}

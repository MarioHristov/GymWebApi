using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class TransactionLog
{
    public string? TransactionId { get; set; }

    public string? CardId { get; set; }

    public virtual CardDetail? Card { get; set; }

    public virtual Transaction? Transaction { get; set; }
}

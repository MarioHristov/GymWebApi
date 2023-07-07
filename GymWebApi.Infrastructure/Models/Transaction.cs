using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class Transaction
{
    public string TransactionId { get; set; } = null!;

    public DateTime? TransactionDate { get; set; }

    public int? TransactionCost { get; set; }

    public string? TransactionDescription { get; set; }
}

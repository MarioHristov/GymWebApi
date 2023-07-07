using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class CardDetail
{
    public string CardId { get; set; } = null!;

    public int? CardCvc { get; set; }

    public string? CardExpDate { get; set; }

    public int? CardBalance { get; set; }

    public long? CardNumber { get; set; }
}

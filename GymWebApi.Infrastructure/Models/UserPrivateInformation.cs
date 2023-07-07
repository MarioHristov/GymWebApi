using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class UserPrivateInformation
{
    public string? UserId { get; set; }

    public string? Pin { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CardId { get; set; }

    public virtual CardDetail? Card { get; set; }
}

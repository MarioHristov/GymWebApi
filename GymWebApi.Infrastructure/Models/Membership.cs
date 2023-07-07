using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class Membership
{
    public string MembershipId { get; set; } = null!;

    public string MembershipType { get; set; } = null!;

    public int MembershipDuration { get; set; }

    public int MembershipBasePricePerMonth { get; set; }
}

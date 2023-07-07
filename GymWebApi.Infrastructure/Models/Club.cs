using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class Club
{
    public string ClubId { get; set; } = null!;

    public string? ClubName { get; set; }

    public string? ClubLocation { get; set; }

    public string? ClubWorkingHours { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}

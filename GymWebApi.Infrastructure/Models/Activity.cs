using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class Activity
{
    public string ActivityId { get; set; } = null!;

    public string? ActivityName { get; set; }

    public DateTime? ActivityDate { get; set; }

    public string? ActivityStartTime { get; set; }

    public string? ActivityEndTime { get; set; }

    public int? ActivityMaxPeople { get; set; }

    public string? ClubId { get; set; }

    public string? TrainerId { get; set; }

    public virtual Club? Club { get; set; }

    public virtual Trainer? Trainer { get; set; }
}

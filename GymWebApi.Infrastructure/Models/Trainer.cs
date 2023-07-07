using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class Trainer
{
    public string TrainerId { get; set; } = null!;

    public string? TrainerSpecialization { get; set; }

    public string? TrainerPicture { get; set; }

    public string? TrainerFirstName { get; set; }

    public string? TrainerLastName { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}

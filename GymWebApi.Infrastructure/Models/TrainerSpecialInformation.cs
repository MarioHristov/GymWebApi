using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class TrainerSpecialInformation
{
    public string? TrainerId { get; set; }

    public string? TrainerPhoneNumber { get; set; }

    public string? TrainerEmail { get; set; }

    public virtual Trainer? Trainer { get; set; }
}

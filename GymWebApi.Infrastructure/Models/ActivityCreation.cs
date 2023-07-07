using System;
using System.Collections.Generic;

namespace GymWebApi.Infrastructure.Models;

public partial class ActivityCreation
{
    public string? ActivityId { get; set; }

    public DateTime? ActivityCreationDate { get; set; }

    public DateTime? ActivityDeletionDate { get; set; }

    public virtual Activity? Activity { get; set; }
}

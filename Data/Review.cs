using System;
using System.Collections.Generic;

namespace Lab2.Data;

public partial class Review
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string? Text { get; set; }

    public int Score { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}

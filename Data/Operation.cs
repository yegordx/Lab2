using System;
using System.Collections.Generic;

namespace Lab2.Data;

public partial class Operation
{
    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public int HospitalId { get; set; }

    public string Info { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}

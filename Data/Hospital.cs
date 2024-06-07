using System;
using System.Collections.Generic;

namespace Lab2.Data;

public partial class Hospital
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}

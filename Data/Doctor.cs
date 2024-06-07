using System;
using System.Collections.Generic;

namespace Lab2.Data;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Post { get; set; } = null!;

    public string? Info { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

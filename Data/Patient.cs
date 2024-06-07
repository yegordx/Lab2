using System;
using System.Collections.Generic;

namespace Lab2.Data;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public int Age { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

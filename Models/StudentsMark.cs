using System;
using System.Collections.Generic;

namespace PProject4.Models;

public partial class StudentsMark
{
    public int Id { get; set; }

    public string Subject { get; set; } = null!;

    public int? Marks { get; set; }

    public int? Students { get; set; }

    public virtual Student? StudentsNavigation { get; set; }
}

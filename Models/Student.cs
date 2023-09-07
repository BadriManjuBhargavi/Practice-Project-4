using System;
using System.Collections.Generic;

namespace PProject4.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public virtual ICollection<StudentsMark> StudentsMarks { get; set; } = new List<StudentsMark>();
}

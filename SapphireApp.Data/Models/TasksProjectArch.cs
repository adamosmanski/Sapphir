﻿using System;
using System.Collections.Generic;

namespace SapphirApp.Data.Models;

public partial class TasksProjectArch
{
    public int Id { get; set; }

    public int IdProjects { get; set; }

    public string ShortNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? AssignedUser { get; set; }

    public string? Tag { get; set; }

    public string Category { get; set; } = null!;

    public DateTime? ModDate { get; set; }

    public int? ModUser { get; set; }
}

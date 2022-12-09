using System;
using System.Collections.Generic;

namespace SapphirApp.Data.Models;

public partial class CommentsArch
{
    public int Id { get; set; }

    public string? ShortTaskName { get; set; }

    public string User { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}

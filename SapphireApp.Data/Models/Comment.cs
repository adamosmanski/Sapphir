using System;
using System.Collections.Generic;

namespace SapphirApp.Data.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string ShortTaskName { get; set; }

    public string User { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}

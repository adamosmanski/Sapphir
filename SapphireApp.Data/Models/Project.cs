using System;
using System.Collections.Generic;

namespace SapphirApp.Data.Models;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ModUser { get; set; }

    public DateTime? ModDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace SapphirApp.Data.Models;

public partial class ProjectsArch
{
    public int Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ModUser { get; set; }

    public DateTime? ModDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace SapphirApp.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string Surname { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public string LevelAccess { get; set; } = null!;

    public DateTime? LastLoginDate { get; set; }

    public int ModUser { get; set; }

    public DateTime ModDate { get; set; }
}

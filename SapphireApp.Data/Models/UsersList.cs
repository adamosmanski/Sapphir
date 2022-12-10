using System;
using System.Collections.Generic;

namespace SapphirApp.Data.Models;

public partial class UsersList
{
    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string Surname { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string LevelAccess { get; set; } = null!;
    public string FullName { get; set; } = null!;

}

using System;
using System.Collections.Generic;

namespace ParcialTienditaUwU.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public bool IsAdmin { get; set; }
}

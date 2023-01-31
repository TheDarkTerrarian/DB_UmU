using System;
using System.Collections.Generic;

namespace ParcialTienditaUwU.Models;

public partial class Sell
{
    public int SellId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime SellDate { get; set; }

    public double TotalToPay { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}

using System;
using System.Collections.Generic;

namespace ParcialTienditaUwU.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public double TotalPrice { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}

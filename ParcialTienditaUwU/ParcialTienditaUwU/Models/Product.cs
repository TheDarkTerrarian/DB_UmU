using System;
using System.Collections.Generic;

namespace ParcialTienditaUwU.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string ProductName { get; set; } = null!;

    public double ProductPrice { get; set; }

    public int Stock { get; set; }

    public string Category { get; set; } = null!;

    public int? OrdersorderId { get; set; }

    public int? SellssellId { get; set; }

    public virtual Order? Ordersorder { get; set; }

    public virtual Sell? Sellssell { get; set; }
}

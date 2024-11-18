using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Color
{
    public int colorId { get; set; }

    public string? ColorName { get; set; }

    public int? Price { get; set; }

    public bool? IsInStock { get; set; }
    public int? presentationOrder { get; set; }
}

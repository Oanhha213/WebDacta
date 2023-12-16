using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Thuonghieu
{
    public int IdTh { get; set; }

    public string TenTh { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}

using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Kichco
{
    public int IdKc { get; set; }

    public string TenKc { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}

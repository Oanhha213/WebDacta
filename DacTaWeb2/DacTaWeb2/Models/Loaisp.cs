using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Loaisp
{
    public int IdLsp { get; set; }

    public string TenLsp { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}

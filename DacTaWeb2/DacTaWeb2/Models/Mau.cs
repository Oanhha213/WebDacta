using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Mau
{
    public int IdMau { get; set; }

    public string Tenmau { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}

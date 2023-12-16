using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Chatvai
{
    public int IdCv { get; set; }

    public string TenCv { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}

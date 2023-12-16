using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Nhacungcap
{
    public int IdNcc { get; set; }

    public string TenNcc { get; set; } = null!;

    public string SdtNcc { get; set; } = null!;

    public virtual ICollection<Phieunhapkho> Phieunhapkhos { get; set; } = new List<Phieunhapkho>();
}

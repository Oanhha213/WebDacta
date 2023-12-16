using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Chitietdd
{
    public int IdCtdd { get; set; }

    public int? IdDd { get; set; }

    public int? IdSp { get; set; }

    public int Soluong { get; set; }

    public double? Tongtien { get; set; }

    public virtual Dondat? IdDdNavigation { get; set; }

    public virtual Sanpham? IdSpNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Chitietsp
{
    public int IdCtsp { get; set; }

    public int? IdCtpnk { get; set; }

    public int? IdSp { get; set; }

    public int? IdCtdd { get; set; }

    public int Ctspthu { get; set; }

    public string? NhanSp { get; set; }

    public string? Tinhtrangban { get; set; }

    public virtual Chitietpnk? IdCtpnkNavigation { get; set; }

    public virtual Sanpham? IdSpNavigation { get; set; }
}

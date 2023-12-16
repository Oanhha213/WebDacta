using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Taikhoan
{
    public int IdTk { get; set; }

    public string Tentk { get; set; } = null!;

    public string TenNguoiDung { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public string Loaitk { get; set; } = null!;

    public virtual ICollection<Dondat> Dondats { get; set; } = new List<Dondat>();

    public virtual ICollection<Phieunhapkho> Phieunhapkhos { get; set; } = new List<Phieunhapkho>();
}

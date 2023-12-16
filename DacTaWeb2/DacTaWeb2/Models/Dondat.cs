using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Dondat
{
    public int IdDd { get; set; }

    public int? IdKh { get; set; }

    public int? IdNv { get; set; }

    public int Landat { get; set; }

    public DateTime Thoigian { get; set; }

    public string? TrangthaiTt { get; set; }

    public double? Tongtien { get; set; }

    public virtual ICollection<Chitietdd> Chitietdds { get; set; } = new List<Chitietdd>();

    public virtual Khachhang? IdKhNavigation { get; set; }

    public virtual Taikhoan? IdNvNavigation { get; set; }
}

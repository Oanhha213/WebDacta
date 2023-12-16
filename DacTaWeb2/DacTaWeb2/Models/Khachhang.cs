using System;
using System.Collections.Generic;

namespace DacTaWeb2.Models;

public partial class Khachhang
{
    public int IdKh { get; set; }

    public string TenKh { get; set; } = null!;

    public string SdtKh { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public virtual ICollection<Dondat> Dondats { get; set; } = new List<Dondat>();
}

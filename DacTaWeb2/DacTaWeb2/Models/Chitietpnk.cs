using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DacTaWeb2.Models;

public partial class Chitietpnk
{
    public int IdCtpnk { get; set; }

    public int? IdPnk { get; set; }

    [DisplayName("Sản phẩm")]
    public int? IdSp { get; set; }

    [DisplayName("Số lượng")]
    public int Soluong { get; set; }

    [DisplayName("Giá nhập")]
    public double? GiaNhap { get; set; }

    [DisplayName("Tổng tiền")]
    public double? Tongtien { get; set; }

    public virtual ICollection<Chitietsp> Chitietsps { get; set; } = new List<Chitietsp>();

    public virtual Phieunhapkho? IdPnkNavigation { get; set; }

    public virtual Sanpham? IdSpNavigation { get; set; }
}

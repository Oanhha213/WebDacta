using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DacTaWeb2.Models;

public partial class Phieunhapkho
{
    public int IdPnk { get; set; }

    [DisplayName("Nhà cung cấp")]
    public int? IdNcc { get; set; }

    [DisplayName("Nhân viên")]
    public int? IdNv { get; set; }

    [DisplayName("Thời gian")]
    public DateTime Thoigian { get; set; }

    [DisplayName("Trạng thái")]
    public string? Trangthai { get; set; }

    [DisplayName("Tổng tiền")]
    public double? Tongtien { get; set; }

    [DisplayName("Mô tả")]
    public string? Mota { get; set; }

    public virtual ICollection<Chitietpnk> Chitietpnks { get; set; } = new List<Chitietpnk>();

    public virtual Nhacungcap? IdNccNavigation { get; set; }

    public virtual Taikhoan? IdNvNavigation { get; set; }
}

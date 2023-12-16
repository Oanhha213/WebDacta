using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DacTaWeb2.Models;

public partial class Sanpham
{
    public int IdSp { get; set; }

    [DisplayName("Tên sản phẩm")]
    public string TenSp { get; set; } = null!;

    [DisplayName("Ảnh sản phẩm")]
    public string? Anh { get; set; }

    [DisplayName("Số lượng")]
    public int Soluong { get; set; }

    [DisplayName("Giá nhập")]
    public double? GiaNhap { get; set; }

    [DisplayName("Giá bán")]
    public double? GiaBan { get; set; }

    [DisplayName("Màu")]
    public int? IdMau { get; set; }

    [DisplayName("Kích cỡ")]
    public int? IdKc { get; set; }

    [DisplayName("Chất vải")]
    public int? IdCv { get; set; }

    [DisplayName("Thương hiệu")]
    public int? IdTh { get; set; }

    [DisplayName("Loại sản phẩm")]
    public int? IdLsp { get; set; }

    [NotMapped]
    public IFormFile? formFile { get; set; }
    public virtual ICollection<Chitietdd> Chitietdds { get; set; } = new List<Chitietdd>();

    public virtual ICollection<Chitietpnk> Chitietpnks { get; set; } = new List<Chitietpnk>();

    public virtual ICollection<Chitietsp> Chitietsps { get; set; } = new List<Chitietsp>();

    public virtual Chatvai? IdCvNavigation { get; set; }

    public virtual Kichco? IdKcNavigation { get; set; }

    public virtual Loaisp? IdLspNavigation { get; set; }

    public virtual Mau? IdMauNavigation { get; set; }

    public virtual Thuonghieu? IdThNavigation { get; set; }
}

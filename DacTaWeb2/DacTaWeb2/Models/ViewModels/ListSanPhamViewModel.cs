namespace DacTaWeb2.Models.ViewModels
{
    public class ListSanPhamViewModel
    {
        public int IdSp { get; set; }
        public string TenSp { get; set; } = null!;

        public string? Anh { get; set; }

        public int Soluong { get; set; }

        public double? GiaNhap { get; set; }

        public double? GiaBan { get; set; }

        public string? TenCV { get; set; }
        public string? TenKC { get; set; }
        public string? TenLSP { get; set; }
        public string? TenMau { get; set; }
        public string? TenTH { get; set; }

        public virtual Chatvai? IdCvNavigation { get; set; }

        public virtual Kichco? IdKcNavigation { get; set; }

        public virtual Loaisp? IdLspNavigation { get; set; }

        public virtual Mau? IdMauNavigation { get; set; }

        public virtual Thuonghieu? IdThNavigation { get; set; }
    }
}

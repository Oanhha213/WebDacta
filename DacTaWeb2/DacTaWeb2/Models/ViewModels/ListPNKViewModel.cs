using System.ComponentModel;

namespace DacTaWeb2.Models.ViewModels
{
    public class ListPNKViewModel
    {
        public int IdPnk { get; set; }
        public string? TenNCC { get; set; }
        public string? TenNV { get; set; }

        [DisplayName("Thời gian")]
        public DateTime Thoigian { get; set; }

        [DisplayName("Trạng thái")]
        public string? Trangthai { get; set; }

        [DisplayName("Tổng tiền")]
        public double? Tongtien { get; set; }

        [DisplayName("Mô tả")]
        public string? Mota { get; set; }

        public virtual Nhacungcap? IdNccNavigation { get; set; }

        public virtual Taikhoan? IdNvNavigation { get; set; }
    }
}

using DacTaWeb2.Models;
using DacTaWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DacTaWeb2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BanQa6Context db = new BanQa6Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstSanPham = db.Sanphams
           .Include(s => s.IdCvNavigation)
           .Include(s => s.IdKcNavigation)
           .Include(s => s.IdLspNavigation)
           .Include(s => s.IdMauNavigation)
           .Include(s => s.IdThNavigation)
           .Select(s => new ListSanPhamViewModel
           {
               IdSp = s.IdSp,
               TenSp = s.TenSp,
               Anh = s.Anh,
               Soluong = s.Soluong,
               GiaNhap = s.GiaNhap,
               GiaBan = s.GiaBan,
               TenCV = s.IdCvNavigation.TenCv,
               TenKC = s.IdKcNavigation.TenKc,
               TenLSP = s.IdLspNavigation.TenLsp,
               TenMau = s.IdMauNavigation.Tenmau,
               TenTH = s.IdThNavigation.TenTh,
           })
           .ToList();

            return View(lstSanPham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.IdMau=new SelectList(db.Maus.ToList(),"IdMau","Tenmau");
            ViewBag.IdKc = new SelectList(db.Kichcos.ToList(), "IdKc", "TenKc");
            ViewBag.IdCv = new SelectList(db.Chatvais.ToList(), "IdCv", "TenCv");
            ViewBag.IdTh = new SelectList(db.Thuonghieus.ToList(), "IdTh", "TenTh");
            ViewBag.IdLsp = new SelectList(db.Loaisps.ToList(), "IdLsp", "TenLsp");
            return View();
        }

        [Route("ThemSanPhamMoi")]
        [HttpPost]
        public IActionResult ThemSanPhamMoi(Sanpham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.Anh = sanPham.formFile.FileName;
                db.Sanphams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int IdSp)
        {
            ViewBag.IdMau = new SelectList(db.Maus.ToList(), "IdMau", "Tenmau");
            ViewBag.IdKc = new SelectList(db.Kichcos.ToList(), "IdKc", "TenKc");
            ViewBag.IdCv = new SelectList(db.Chatvais.ToList(), "IdCv", "TenCv");
            ViewBag.IdTh = new SelectList(db.Thuonghieus.ToList(), "IdTh", "TenTh");
            ViewBag.IdLsp = new SelectList(db.Loaisps.ToList(), "IdLsp", "TenLsp");
            var sanPham = db.Sanphams.Find(IdSp);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        public IActionResult SuaSanPham(Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                sanpham.Anh = sanpham.formFile.FileName;
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanpham);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int IdSp)
        {
            TempData["Message"] = "";
            var listCTSP = db.Chitietsps.Where(x => x.IdSp == IdSp);
            var listCTDD = db.Chitietdds.Where(x => x.IdSp == IdSp);
            var listCTPNK = db.Chitietpnks.Where(x => x.IdSp == IdSp);
            foreach (var item in listCTSP)
            {
                if (db.Chitietsps.Where(x => x.IdCtsp == item.IdCtsp) != null)
                {
                    TempData["Message"] = "Không xóa được sản phẩm!";
                    return RedirectToAction("Index");
                }
            }
            foreach (var item in listCTDD)
            {
                if (db.Chitietdds.Where(x => x.IdCtdd == item.IdCtdd) != null)
                {
                    TempData["Message"] = "Không xóa được sản phẩm!";
                    return RedirectToAction("Index");
                }
            }
            foreach (var item in listCTPNK)
            {
                if (db.Chitietpnks.Where(x => x.IdCtpnk == item.IdCtpnk) != null)
                {
                    TempData["Message"] = "Không xóa được sản phẩm!";
                    return RedirectToAction("Index");
                }
            }
            db.Remove(db.Sanphams.Find(IdSp));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xoá";
            return RedirectToAction("Index");
        }

        [Route("ListPhieuNhapKho")]
        public IActionResult ListPhieuNhapKho()
        {
            var lstPNK = db.Phieunhapkhos
           .Include(s => s.IdNccNavigation)
           .Include(s => s.IdNvNavigation)
           .Select(s => new ListPNKViewModel
           {
               IdPnk = s.IdPnk,
               TenNCC = s.IdNccNavigation.TenNcc,
               TenNV = s.IdNvNavigation.TenNguoiDung,
               Thoigian=s.Thoigian,
               Trangthai=s.Trangthai,
               Tongtien=s.Tongtien,
               Mota=s.Mota
           })
           .ToList();

            return View(lstPNK);
        }

        [Route("TestForm")]
        public IActionResult TestForm()
        {
            return View();
        }

        [Route("ThemPhieuNhapKho2")]
        [HttpGet]
        public IActionResult ThemPhieuNhapKho2()
        {
            ViewBag.IdNcc = new SelectList(db.Nhacungcaps.ToList(), "IdNcc", "TenNcc");
            ViewBag.IdNv = new SelectList(db.Taikhoans.ToList(), "IdTk", "TenNguoiDung");
            return View();
        }

        [Route("ThemPhieuNhapKho2")]
        [HttpPost]
        public IActionResult ThemPhieuNhapKho2(Phieunhapkho phieuNK)
        {
            if (ModelState.IsValid)
            {
                db.Phieunhapkhos.Add(phieuNK);
                db.SaveChanges();

                // Lưu thông tin phiếu nhập kho vào Session
                HttpContext.Session.SetObject("PhieuNhapKho", phieuNK);

                return RedirectToAction("ThemChiTietPhieuNhapKho");
            }
            return View(phieuNK);
        }

        [HttpGet]
        [Route("ThemChiTietPhieuNhapKho/{id}")]
        public IActionResult ThemChiTietPhieuNhapKho(int id)
        {
            // Lấy thông tin phiếu nhập kho theo id
            var phieuNhapKho = db.Phieunhapkhos.Find(id);

            // Kiểm tra nếu không tìm thấy phiếu nhập kho
            if (phieuNhapKho == null)
            {
                return NotFound();
            }

            // Truyền thông tin phiếu nhập kho và danh sách sản phẩm vào view
            ViewBag.PhieuNhapKho = phieuNhapKho;
            ViewBag.SanPhams = new SelectList(db.Sanphams.ToList(), "IdSp", "TenSp");

            return View();
        }

        [HttpPost]
        [Route("ThemChiTietPhieuNhapKho/{id}")]
        public IActionResult ThemChiTietPhieuNhapKho(int id, Chitietpnk chiTietPNK)
        {
            try
            {
                // Lấy thông tin phiếu nhập kho theo id
                var phieuNhapKho = db.Phieunhapkhos.Find(id);

                // Kiểm tra nếu không tìm thấy phiếu nhập kho
                if (phieuNhapKho == null)
                {
                    return NotFound();
                }

                // Thực hiện lưu thông tin chi tiết phiếu nhập kho vào CSDL
                if (ModelState.IsValid)
                {
                    // Gán IdPnk cho chi tiết phiếu nhập kho
                    chiTietPNK.IdPnk = phieuNhapKho.IdPnk;

                    // Thêm chi tiết vào danh sách chi tiết của phiếu nhập kho
                    phieuNhapKho.Chitietpnks.Add(chiTietPNK);

                    // Cập nhật tổng tiền cho phiếu nhập kho (có thể cần cập nhật lại logic tính tổng tiền tùy thuộc vào yêu cầu của bạn)
                    phieuNhapKho.Tongtien += chiTietPNK.Tongtien;

                    // Lưu thay đổi vào CSDL
                    db.SaveChanges();

                    // Chuyển về trang chi tiết phiếu nhập kho
                    return RedirectToAction("ListPhieuNhapKho");
                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return View(chiTietPNK);
        }
    }
}
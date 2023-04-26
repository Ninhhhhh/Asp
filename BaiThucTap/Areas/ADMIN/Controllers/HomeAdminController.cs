using BaiThucTap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace BaiThucTap.Areas.ADMIN.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlcayCanhContext db = new QlcayCanhContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        //San phẩm
        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham()
        {
            var lstSanPham = db.SanPhams.OrderBy(x=>x.TenSp).ToList();
            return View(lstSanPham);
        }
        [Route("ThemSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.Idloai = new SelectList(db.LoaiSps.ToList(), "Idloai", "TenLoai");
            return View();
        }
        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra QuocTich chỉ chứa các chữ cái bằng biểu thức chính quy
                string pattern = "^[0-9]+$";
                if (Regex.IsMatch(sanPham.Gia.ToString(), pattern))
                {
                    // Kiểm tra ảnh có phải là định dạng .jpg hay không
                    if (sanPham.AnhDaiDien != null && Path.GetExtension(sanPham.AnhDaiDien) == ".jpg")
                    {
                        db.SanPhams.Add(sanPham);
                        db.SaveChanges();
                        return RedirectToAction("DanhMucSanPham");
                    }
                    else if (sanPham.AnhDaiDien != null)
                    {
                        ModelState.AddModelError(nameof(sanPham.AnhDaiDien), "Hình ảnh phải có định dạng .jpg.");
                        ViewBag.Idloai = new SelectList(db.LoaiSps.ToList(), "Idloai", "TenLoai");
                    }
                    else
                    {
                        db.SanPhams.Add(sanPham);
                        db.SaveChanges();
                        return RedirectToAction("DanhMucSanPham");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(sanPham.Gia), "Giá Phải Nhập Số.");
                }
            }
            else
            {
                // Bắt lỗi khi QuocTich không phải là chữ cái
                if (!string.IsNullOrEmpty(sanPham.Gia.ToString()))
                {
                    string pattern = "^[0-9]+$";
                    if (!Regex.IsMatch(sanPham.Gia.ToString(), pattern))
                    {
                        ModelState.AddModelError(nameof(sanPham.Gia), "Giá Phải Nhập Số");
                        ViewBag.Idloai = new SelectList(db.LoaiSps.ToList(), "Idloai", "TenLoai");
                    }
                }
            }
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.Idloai = new SelectList(db.LoaiSps.ToList(), "Idloai", "TenLoai");
            var sanPham = db.SanPhams.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra QuocTich chỉ chứa các chữ cái bằng biểu thức chính quy
                string pattern = "^[0-9]+$";
                if (Regex.IsMatch(sanPham.Gia.ToString(), pattern))
                {
                    // Kiểm tra ảnh có phải là định dạng .jpg hay không
                    if (sanPham.AnhDaiDien != null && Path.GetExtension(sanPham.AnhDaiDien) == ".jpg")
                    {
                        db.Update(sanPham);
                        db.SaveChanges();
                        return RedirectToAction("DanhMucSanPham");
                    }
                    else if (sanPham.AnhDaiDien != null)
                    {
                        ModelState.AddModelError(nameof(sanPham.AnhDaiDien), "Hình ảnh phải có định dạng .jpg.");
                        ViewBag.Idloai = new SelectList(db.LoaiSps.ToList(), "Idloai", "TenLoai");
                    }
                    else
                    {
                        db.Update(sanPham);
                        db.SaveChanges();
                        return RedirectToAction("DanhMucSanPham");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(sanPham.Gia), "Giá Phải Nhập Số.");
                }
            }
            else
            {
                // Bắt lỗi khi QuocTich không phải là chữ cái
                if (!string.IsNullOrEmpty(sanPham.Gia.ToString()))
                {
                    string pattern = "^[0-9]+$";
                    if (!Regex.IsMatch(sanPham.Gia.ToString(), pattern))
                    {
                        ModelState.AddModelError(nameof(sanPham.Gia), "Giá Phải Nhập Số");
                        ViewBag.Idloai = new SelectList(db.LoaiSps.ToList(), "Idloai", "TenLoai");
                    }
                }

      
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var ChiTietSp = db.ChiTietSanPhams.Where(x => x.Id == maSanPham).ToList();
            if (ChiTietSp.Count() > 0)
            {
                TempData["Message"] = "Không Thể Xóa Được";
                return RedirectToAction("DanhMucSanPham");
            }
            db.Remove(db.SanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản Phẩm Đã Được Xóa";
            return RedirectToAction("DanhMucSanPham");
        }
        //Nhân Viên
        [Route("DanhSachNhanVien")]
        public IActionResult DanhSachNhanVien()
        {
            var lstSanPham = db.NhanViens.ToList();
            return View(lstSanPham);
        }
        [Route("ThemNhanVien")]
        [HttpGet]
        public IActionResult ThemNhanVien()
        {
            ViewBag.Username = new SelectList(db.Users.ToList(), "Username", "LoaiUser");
            return View();
        }
        [Route("ThemNhanVien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanVien(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                string pattern = "^[0-9]+$";
                if (Regex.IsMatch(nhanVien.SoDt, pattern))
                {
                    // Kiểm tra ảnh có phải là định dạng .jpg hay không
                    if (nhanVien.AnhDaiDien != null && Path.GetExtension(nhanVien.AnhDaiDien) == ".jpg")
                    {
                        db.NhanViens.Add(nhanVien);
                        db.SaveChanges();
                        return RedirectToAction("DanhSachNhanVien");
                    }
                    else if (nhanVien.AnhDaiDien != null)
                    {
                        ModelState.AddModelError(nameof(nhanVien.AnhDaiDien), "Hình ảnh phải có định dạng .jpg.");
                        ViewBag.Username = new SelectList(db.Users.ToList(), "Username", "LoaiUser");
                    }
                    else
                    {
                        db.NhanViens.Add(nhanVien);
                        db.SaveChanges();
                        return RedirectToAction("DanhSachNhanVien");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(nhanVien.SoDt), "Giá Phải Nhập Số.");
                }
            }
            else
            {
                // Bắt lỗi khi QuocTich không phải là chữ cái
                if (!string.IsNullOrEmpty(nhanVien.SoDt))
                {
                    string pattern = "^[0-9]+$";
                    if (!Regex.IsMatch(nhanVien.SoDt, pattern))
                    {
                        ModelState.AddModelError(nameof(nhanVien.SoDt), "Số Điện Thoại Phải Nhập Số");
                        ViewBag.Username = new SelectList(db.Users.ToList(), "Username", "LoaiUser");
                    }
                }
            }
            return View(nhanVien);
        }
        [Route("SuaNhanVien")]
        [HttpGet]
        public IActionResult SuaNhanVien(string maNhanVien)
        {
            ViewBag.Username = new SelectList(db.Users.ToList(), "Username", "LoaiUser");
            var nhanVien = db.NhanViens.Find(maNhanVien);
            return View(nhanVien);
        }
        [Route("SuaNhanVien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {

                string pattern = "^[0-9]+$";
                if (Regex.IsMatch(nhanVien.SoDt, pattern))
                {
                    // Kiểm tra ảnh có phải là định dạng .jpg hay không
                    if (nhanVien.AnhDaiDien != null && Path.GetExtension(nhanVien.AnhDaiDien) == ".jpg")
                    {
                        db.NhanViens.Update(nhanVien);
                        db.SaveChanges();
                        return RedirectToAction("DanhSachNhanVien");
                    }
                    else if (nhanVien.AnhDaiDien != null)
                    {
                        ModelState.AddModelError(nameof(nhanVien.AnhDaiDien), "Hình ảnh phải có định dạng .jpg.");
                        ViewBag.Username = new SelectList(db.Users.ToList(), "Username", "LoaiUser");
                    }
                    else
                    {
                        db.NhanViens.Update(nhanVien);
                        db.SaveChanges();
                        return RedirectToAction("DanhSachNhanVien");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(nhanVien.SoDt), "Giá Phải Nhập Số.");
                }
            }
            else
            {
                // Bắt lỗi khi QuocTich không phải là chữ cái
                if (!string.IsNullOrEmpty(nhanVien.SoDt))
                {
                    string pattern = "^[0-9]+$";
                    if (!Regex.IsMatch(nhanVien.SoDt, pattern))
                    {
                        ModelState.AddModelError(nameof(nhanVien.SoDt), "Số Điện Thoại Phải Nhập Số");
                        ViewBag.Username = new SelectList(db.Users.ToList(), "Username", "LoaiUser");
                    }
                }

            }
            return View(nhanVien);
        }
        [Route("XoaNhanVien")]
        [HttpGet]
        public IActionResult XoaNhanVien(string maNhanVien)
        {
            TempData["Message"] = "";
            var ChiTietSp = db.HoaDonBans.Where(x => x.IdnhanVien == maNhanVien).ToList();
            if (ChiTietSp.Count() > 0)
            {
                TempData["Message"] = "Không Thể Xóa Được";
                return RedirectToAction("DanhSachNhanVien");
            }
            db.Remove(db.NhanViens.Find(maNhanVien));
            db.SaveChanges();
            TempData["Message"] = "Nhân Viên Đã Được Xóa";
            return RedirectToAction("DanhSachNhanVien");
        }
    }
}

using System;
using System.Collections.Generic;

namespace BaiThucTap.Models;

public partial class HoaDonBan
{
    public string IdhoaDon { get; set; } = null!;

    public string? NgayHoaDon { get; set; }

    public string? Idkhach { get; set; }

    public string? IdnhanVien { get; set; }

    public decimal? TongTien { get; set; }

    public string? GiamGia { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public virtual KhachHang? IdkhachNavigation { get; set; }

    public virtual NhanVien? IdnhanVienNavigation { get; set; }
}

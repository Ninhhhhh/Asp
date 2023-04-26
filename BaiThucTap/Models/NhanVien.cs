using System;
using System.Collections.Generic;

namespace BaiThucTap.Models;

public partial class NhanVien
{
    public string IdnhanVien { get; set; } = null!;

    public string? TenNv { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? SoDt { get; set; }

    public string? GioiTinh { get; set; }

    public string? Username { get; set; }

    public string? ChucVu { get; set; }

    public string? AnhDaiDien { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();

    public virtual User? UsernameNavigation { get; set; }
}

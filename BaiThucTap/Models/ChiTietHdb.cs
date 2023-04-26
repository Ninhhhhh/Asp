using System;
using System.Collections.Generic;

namespace BaiThucTap.Models;

public partial class ChiTietHdb
{
    public string IdhoaDon { get; set; } = null!;

    public int? Slban { get; set; }

    public decimal? DonGiaBan { get; set; }

    public string? GiamGia { get; set; }

    public string IdchiTiet { get; set; } = null!;

    public virtual ChiTietSanPham IdchiTietNavigation { get; set; } = null!;

    public virtual HoaDonBan IdhoaDonNavigation { get; set; } = null!;
}

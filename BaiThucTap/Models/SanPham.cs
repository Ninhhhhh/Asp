using System;
using System.Collections.Generic;

namespace BaiThucTap.Models;

public partial class SanPham
{
    public string Id { get; set; } = null!;

    public string? TenSp { get; set; }

    public decimal? Gia { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? Idloai { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual LoaiSp? IdloaiNavigation { get; set; }
}

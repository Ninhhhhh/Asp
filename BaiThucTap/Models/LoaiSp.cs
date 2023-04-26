using System;
using System.Collections.Generic;

namespace BaiThucTap.Models;

public partial class LoaiSp
{
    public string Idloai { get; set; } = null!;

    public string? TenLoai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

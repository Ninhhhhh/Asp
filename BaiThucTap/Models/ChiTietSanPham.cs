using System;
using System.Collections.Generic;

namespace BaiThucTap.Models;

public partial class ChiTietSanPham
{
    public string IdchiTiet { get; set; } = null!;

    public string? ChieuCao { get; set; }

    public string? KichThuocChau { get; set; }

    public string? DoKho { get; set; }

    public string? YcanhSang { get; set; }

    public string? Ycnuoc { get; set; }

    public string? DonGiaBan { get; set; }

    public string? Id { get; set; }

    public string? AnhMinhHoa { get; set; }

    public string? NoiDung { get; set; }

    public string? TenGoi { get; set; }

    public virtual SanPham? IdNavigation { get; set; }
}

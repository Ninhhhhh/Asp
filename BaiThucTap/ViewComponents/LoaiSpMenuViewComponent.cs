using BaiThucTap.Models;
using BaiThucTap.Reponsitory;
using Microsoft.AspNetCore.Mvc;

namespace Bai9_Eshopper.ViewComponents
{
	public class LoaiSpMenuViewComponent : ViewComponent
	{
		private readonly ISanPhamTheoLoai _loaiSp;

		public LoaiSpMenuViewComponent(ISanPhamTheoLoai loaiSp)
		{
			_loaiSp = loaiSp;
		}
		public IViewComponentResult Invoke()
		{
            var LoaiSp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Idloai);
            return View(LoaiSp);
        }
	}
}

using BaiThucTap.Models;
namespace BaiThucTap.Reponsitory
{
	public interface ISanPhamTheoLoai
	{
        LoaiSp Add(LoaiSp loaiSp);
        LoaiSp Update(LoaiSp caulacbo);
        LoaiSp Delete(String idSp);
        LoaiSp GetLoaiSp(String idSp);
        IEnumerable<LoaiSp> GetAllLoaiSp();
    }
}

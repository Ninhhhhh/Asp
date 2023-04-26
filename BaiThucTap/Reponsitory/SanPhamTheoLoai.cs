using BaiThucTap.Models;

namespace BaiThucTap.Reponsitory
{
	public class SanPhamTheoLoai : ISanPhamTheoLoai
	{
		private readonly QlcayCanhContext _context;

        public SanPhamTheoLoai(QlcayCanhContext context)
        {
            _context = context;
        }

        public LoaiSp Add(LoaiSp loaiSp)
        {
            _context.LoaiSps.Add(loaiSp);
             _context.SaveChanges();
             return loaiSp;
        }

        public LoaiSp Delete(string idSp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiSp> GetAllLoaiSp()
        {
            return _context.LoaiSps;
        }

        public LoaiSp GetLoaiSp(string idSp)
        {
            return _context.LoaiSps.Find(idSp);
        }

        public LoaiSp Update(LoaiSp idSp)
        {
            _context.Update(idSp);
            _context.SaveChanges();
            return idSp;
        }



   
    }
}

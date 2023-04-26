using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaiThucTap.Models;
using BaiThucTap.CauThuModels;

namespace BaiThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CayCanhController : ControllerBase
    {
        QlcayCanhContext db= new QlcayCanhContext();
        [HttpGet]
        public IEnumerable<CayCanh>GetAllCauthu()
        {
            var cayCanh = (from p in db.SanPhams
                           select new CayCanh
                           {
                               Id = p.Id,
                               TenSp = p.TenSp,
                               Gia = p.Gia,
                               Idloai = p.Idloai,
                               AnhDaiDien = p.AnhDaiDien,
                           }).ToList();
            return cayCanh;  
        }
        [HttpGet("{IdLoai}")]
        public IEnumerable<CayCanh> GetAllCauthuByCategory(string IdLoai)
        {
            var cayCanh = (from p in db.SanPhams
                           where p.Idloai == IdLoai
                           select new CayCanh
                          {
                              Id = p.Id,
                              TenSp = p.TenSp,
                              Gia = p.Gia,
                              Idloai = p.Idloai,
                              AnhDaiDien = p.AnhDaiDien,
                          }).ToList();
            return cayCanh;
        }

    }
}

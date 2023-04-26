using Azure;
using BaiThucTap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace BaiThucTap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlcayCanhContext db = new QlcayCanhContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstCayCanh = db.SanPhams.AsNoTracking().OrderBy(x => x.Id);
            return View(lstCayCanh);
        }
   
        public IActionResult Shop(int? page)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstCayCanh = db.SanPhams.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<SanPham> lst = new PagedList<SanPham>(lstCayCanh, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
       
        public IActionResult ChiTietSanPham(String maSp)
        {
            var sanPham = db.ChiTietSanPhams.SingleOrDefault(x => x.Id == maSp);

            return View(sanPham);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
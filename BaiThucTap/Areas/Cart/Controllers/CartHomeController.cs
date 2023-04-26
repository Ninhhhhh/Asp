using BaiThucTap.Models;
using BaiThucTap.Models.Cart;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaiThucTap.Areas.Cart.Controllers
{
    [Area("cart")]
    [Route("cart")]
    public class CartHomeController : Controller
    {
        QlcayCanhContext db = new QlcayCanhContext();

        private const string CartSession = "CartSession";
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            TempData["Message"] = "Sản phẩm đã được thêm vào giỏ hàng";

            var cart = HttpContext.Session.GetString(CartSession);
            var list = new List<Cartitem>();

            if (cart != null)
            {
                var productList = JsonConvert.DeserializeObject<List<Cartitem>>(cart);
                list = productList;
            }
            return View(list);
        }
        [Route("AddiItem")]
        public ActionResult AddiItem(string id, int quantity)
        {
            var cart = HttpContext.Session.GetString(CartSession);
            if (cart != null)
            {
                var productList = JsonConvert.DeserializeObject<List<Cartitem>>(cart);
                var item = productList.Find(p => p.sanPham.Id == Convert.ToString(id));

                if (item != null)
                {
                    item.SoLuong += quantity;
                }
                else
                {
                    var sanPham = db.SanPhams.Find(id);
                    if (sanPham != null)
                    {
                        item = new Cartitem();
                        item.sanPham = sanPham;
                        item.SoLuong = quantity;
                        productList.Add(item);
                    }
                }
                cart = JsonConvert.SerializeObject(productList);
                HttpContext.Session.SetString(CartSession, cart);
            }
            else
            {
                var sanPham = db.SanPhams.Find(id);
                if (sanPham != null)
                {
                    var item = new Cartitem();
                    item.sanPham = sanPham;
                    item.SoLuong = quantity;
                    var list = new List<Cartitem>();
                    list.Add(item);
                    cart = JsonConvert.SerializeObject(list);
                    HttpContext.Session.SetString(CartSession, cart);
                }
            }
            return RedirectToAction("Index");
        }
    }
}

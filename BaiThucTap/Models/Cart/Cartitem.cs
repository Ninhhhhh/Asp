namespace BaiThucTap.Models.Cart
{
    [Serializable]
    public class Cartitem
    {
        public SanPham sanPham { get; set; }
        public int SoLuong { get; set; }
        // các thuộc tính khác của đối tượng Cartitem
    }
}

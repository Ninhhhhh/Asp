using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaiThucTap.Models;

public partial class QlcayCanhContext : DbContext
{
    public QlcayCanhContext()
    {
    }

    public QlcayCanhContext(DbContextOptions<QlcayCanhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NINHH;Initial Catalog=QLCayCanh;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHdb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChiTietHDB");

            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.GiamGia).HasMaxLength(50);
            entity.Property(e => e.IdchiTiet)
                .HasMaxLength(50)
                .HasColumnName("IDChiTiet");
            entity.Property(e => e.IdhoaDon)
                .HasMaxLength(50)
                .HasColumnName("IDHoaDon");
            entity.Property(e => e.Slban).HasColumnName("SLBan");

            entity.HasOne(d => d.IdchiTietNavigation).WithMany()
                .HasForeignKey(d => d.IdchiTiet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHDB_ChiTietSanPham1");

            entity.HasOne(d => d.IdhoaDonNavigation).WithMany()
                .HasForeignKey(d => d.IdhoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHDB_HoaDonBan1");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.IdchiTiet);

            entity.ToTable("ChiTietSanPham");

            entity.Property(e => e.IdchiTiet)
                .HasMaxLength(50)
                .HasColumnName("IDChiTiet");
            entity.Property(e => e.AnhMinhHoa).HasMaxLength(50);
            entity.Property(e => e.ChieuCao).HasMaxLength(50);
            entity.Property(e => e.DoKho).HasMaxLength(50);
            entity.Property(e => e.DonGiaBan).HasMaxLength(50);
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.KichThuocChau).HasMaxLength(50);
            entity.Property(e => e.YcanhSang)
                .HasMaxLength(50)
                .HasColumnName("YCAnhSang");
            entity.Property(e => e.Ycnuoc)
                .HasMaxLength(50)
                .HasColumnName("YCNuoc");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_ChiTietSanPham_SanPham");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.IdhoaDon);

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.IdhoaDon)
                .HasMaxLength(50)
                .HasColumnName("IDHoaDon");
            entity.Property(e => e.GiamGia).HasMaxLength(50);
            entity.Property(e => e.Idkhach)
                .HasMaxLength(50)
                .HasColumnName("IDKhach");
            entity.Property(e => e.IdnhanVien)
                .HasMaxLength(50)
                .HasColumnName("IDNhanVien");
            entity.Property(e => e.NgayHoaDon).HasMaxLength(50);
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.IdkhachNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.Idkhach)
                .HasConstraintName("FK_HoaDonBan_KhachHang");

            entity.HasOne(d => d.IdnhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.IdnhanVien)
                .HasConstraintName("FK_HoaDonBan_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Idkhach);

            entity.ToTable("KhachHang");

            entity.Property(e => e.Idkhach)
                .HasMaxLength(50)
                .HasColumnName("IDKhach");
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDt)
                .HasMaxLength(50)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_KhachHang_User");
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.Idloai);

            entity.ToTable("LoaiSP");

            entity.Property(e => e.Idloai)
                .HasMaxLength(50)
                .HasColumnName("IDLoai");
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdnhanVien);

            entity.ToTable("NhanVien");

            entity.Property(e => e.IdnhanVien)
                .HasMaxLength(50)
                .HasColumnName("IDNhanVien");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(50)
                .HasColumnName("AnhDaiDIen");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDt)
                .HasMaxLength(50)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_NhanVien_User");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.ToTable("SanPham");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.Gia).HasColumnType("money");
            entity.Property(e => e.Idloai)
                .HasMaxLength(50)
                .HasColumnName("IDLoai");
            entity.Property(e => e.TenSp)
                .HasMaxLength(100)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.IdloaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.Idloai)
                .HasConstraintName("FK_SanPham_LoaiSP");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("User");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.LoaiUser).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

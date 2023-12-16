using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DacTaWeb2.Models;

public partial class BanQa6Context : DbContext
{
    public BanQa6Context()
    {
    }

    public BanQa6Context(DbContextOptions<BanQa6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Chatvai> Chatvais { get; set; }

    public virtual DbSet<Chitietdd> Chitietdds { get; set; }

    public virtual DbSet<Chitietpnk> Chitietpnks { get; set; }

    public virtual DbSet<Chitietsp> Chitietsps { get; set; }

    public virtual DbSet<Dondat> Dondats { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Kichco> Kichcos { get; set; }

    public virtual DbSet<Loaisp> Loaisps { get; set; }

    public virtual DbSet<Mau> Maus { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Phieunhapkho> Phieunhapkhos { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7JF815G;Initial Catalog=BanQA6;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chatvai>(entity =>
        {
            entity.HasKey(e => e.IdCv).HasName("PK__CHATVAI__16EC97CBB09BDFC5");

            entity.ToTable("CHATVAI");

            entity.Property(e => e.IdCv).HasColumnName("Id_CV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(50)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<Chitietdd>(entity =>
        {
            entity.HasKey(e => e.IdCtdd).HasName("PK__CHITIETD__A09D30854133D7C1");

            entity.ToTable("CHITIETDD");

            entity.HasIndex(e => new { e.IdDd, e.IdSp }, "DD_SP").IsUnique();

            entity.Property(e => e.IdCtdd).HasColumnName("Id_CTDD");
            entity.Property(e => e.IdDd).HasColumnName("Id_DD");
            entity.Property(e => e.IdSp).HasColumnName("Id_SP");

            entity.HasOne(d => d.IdDdNavigation).WithMany(p => p.Chitietdds)
                .HasForeignKey(d => d.IdDd)
                .HasConstraintName("FK__CHITIETDD__Id_DD__5CD6CB2B");

            entity.HasOne(d => d.IdSpNavigation).WithMany(p => p.Chitietdds)
                .HasForeignKey(d => d.IdSp)
                .HasConstraintName("FK__CHITIETDD__Id_SP__5DCAEF64");
        });

        modelBuilder.Entity<Chitietpnk>(entity =>
        {
            entity.HasKey(e => e.IdCtpnk).HasName("PK__CHITIETP__8A07A9A8014F7F3E");

            entity.ToTable("CHITIETPNK");

            entity.HasIndex(e => new { e.IdPnk, e.IdSp }, "PNK_SP").IsUnique();

            entity.Property(e => e.IdCtpnk).HasColumnName("Id_CTPNK");
            entity.Property(e => e.IdPnk).HasColumnName("Id_PNK");
            entity.Property(e => e.IdSp).HasColumnName("Id_SP");

            entity.HasOne(d => d.IdPnkNavigation).WithMany(p => p.Chitietpnks)
                .HasForeignKey(d => d.IdPnk)
                .HasConstraintName("FK__CHITIETPN__Id_PN__5812160E");

            entity.HasOne(d => d.IdSpNavigation).WithMany(p => p.Chitietpnks)
                .HasForeignKey(d => d.IdSp)
                .HasConstraintName("FK__CHITIETPN__Id_SP__59063A47");
        });

        modelBuilder.Entity<Chitietsp>(entity =>
        {
            entity.HasKey(e => e.IdCtsp).HasName("PK__CHITIETS__A09A8ABC2D975C0E");

            entity.ToTable("CHITIETSP");

            entity.HasIndex(e => new { e.IdSp, e.Ctspthu }, "CTSP_SP").IsUnique();

            entity.Property(e => e.IdCtsp).HasColumnName("Id_CTSP");
            entity.Property(e => e.Ctspthu).HasColumnName("CTSPThu");
            entity.Property(e => e.IdCtdd).HasColumnName("Id_CTDD");
            entity.Property(e => e.IdCtpnk).HasColumnName("Id_CTPNK");
            entity.Property(e => e.IdSp).HasColumnName("Id_SP");
            entity.Property(e => e.NhanSp)
                .HasMaxLength(10)
                .HasColumnName("NhanSP");
            entity.Property(e => e.Tinhtrangban).HasMaxLength(10);

            entity.HasOne(d => d.IdCtpnkNavigation).WithMany(p => p.Chitietsps)
                .HasForeignKey(d => d.IdCtpnk)
                .HasConstraintName("FK__CHITIETSP__Id_CT__619B8048");

            entity.HasOne(d => d.IdSpNavigation).WithMany(p => p.Chitietsps)
                .HasForeignKey(d => d.IdSp)
                .HasConstraintName("FK__CHITIETSP__Id_SP__628FA481");
        });

        modelBuilder.Entity<Dondat>(entity =>
        {
            entity.HasKey(e => e.IdDd).HasName("PK__DONDAT__16EC9FC4E1AFE15E");

            entity.ToTable("DONDAT");

            entity.HasIndex(e => new { e.IdKh, e.Landat }, "TK_DD").IsUnique();

            entity.Property(e => e.IdDd).HasColumnName("Id_DD");
            entity.Property(e => e.IdKh).HasColumnName("Id_KH");
            entity.Property(e => e.IdNv).HasColumnName("Id_NV");
            entity.Property(e => e.Thoigian).HasColumnType("date");
            entity.Property(e => e.TrangthaiTt)
                .HasMaxLength(20)
                .HasColumnName("TrangthaiTT");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.Dondats)
                .HasForeignKey(d => d.IdKh)
                .HasConstraintName("FK__DONDAT__Id_KH__534D60F1");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.Dondats)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__DONDAT__Id_NV__5441852A");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.IdKh).HasName("PK__KHACHHAN__16ECD6E7B16358C9");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.IdKh).HasColumnName("Id_KH");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.SdtKh)
                .HasMaxLength(20)
                .HasColumnName("SDT_KH");
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<Kichco>(entity =>
        {
            entity.HasKey(e => e.IdKc).HasName("PK__KICHCO__16ECD6FC23B1A41E");

            entity.ToTable("KICHCO");

            entity.Property(e => e.IdKc).HasColumnName("Id_KC");
            entity.Property(e => e.TenKc)
                .HasMaxLength(50)
                .HasColumnName("TenKC");
        });

        modelBuilder.Entity<Loaisp>(entity =>
        {
            entity.HasKey(e => e.IdLsp).HasName("PK__LOAISP__5CA1AF4E5266956B");

            entity.ToTable("LOAISP");

            entity.Property(e => e.IdLsp).HasColumnName("Id_LSP");
            entity.Property(e => e.TenLsp)
                .HasMaxLength(100)
                .HasColumnName("TenLSP");
        });

        modelBuilder.Entity<Mau>(entity =>
        {
            entity.HasKey(e => e.IdMau).HasName("PK__MAU__5C6013207C376080");

            entity.ToTable("MAU");

            entity.Property(e => e.IdMau).HasColumnName("Id_Mau");
            entity.Property(e => e.Tenmau).HasMaxLength(50);
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.IdNcc).HasName("PK__NHACUNGC__5C211135EC4F586E");

            entity.ToTable("NHACUNGCAP");

            entity.Property(e => e.IdNcc).HasColumnName("Id_NCC");
            entity.Property(e => e.SdtNcc)
                .HasMaxLength(20)
                .HasColumnName("SDT_NCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<Phieunhapkho>(entity =>
        {
            entity.HasKey(e => e.IdPnk).HasName("PK__PHIEUNHA__51E04ED8EB4874FF");

            entity.ToTable("PHIEUNHAPKHO");

            entity.HasIndex(e => new { e.IdNv, e.Thoigian }, "TK_PNK").IsUnique();

            entity.Property(e => e.IdPnk).HasColumnName("Id_PNK");
            entity.Property(e => e.IdNcc).HasColumnName("Id_NCC");
            entity.Property(e => e.IdNv).HasColumnName("Id_NV");
            entity.Property(e => e.Mota)
                .HasMaxLength(200)
                .HasColumnName("mota");
            entity.Property(e => e.Thoigian).HasColumnType("date");
            entity.Property(e => e.Tongtien).HasColumnName("tongtien");
            entity.Property(e => e.Trangthai).HasMaxLength(20);

            entity.HasOne(d => d.IdNccNavigation).WithMany(p => p.Phieunhapkhos)
                .HasForeignKey(d => d.IdNcc)
                .HasConstraintName("FK__PHIEUNHAP__Id_NC__4E88ABD4");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.Phieunhapkhos)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__PHIEUNHAP__Id_NV__4F7CD00D");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.IdSp).HasName("PK__SANPHAM__16EC11E507BE4CCA");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.IdSp).HasColumnName("Id_SP");
            entity.Property(e => e.Anh).HasMaxLength(250);
            entity.Property(e => e.IdCv).HasColumnName("Id_CV");
            entity.Property(e => e.IdKc).HasColumnName("Id_KC");
            entity.Property(e => e.IdLsp).HasColumnName("Id_LSP");
            entity.Property(e => e.IdMau).HasColumnName("Id_Mau");
            entity.Property(e => e.IdTh).HasColumnName("Id_TH");
            entity.Property(e => e.TenSp)
                .HasMaxLength(200)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdCv)
                .HasConstraintName("FK__SANPHAM__Id_CV__48CFD27E");

            entity.HasOne(d => d.IdKcNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdKc)
                .HasConstraintName("FK__SANPHAM__Id_KC__47DBAE45");

            entity.HasOne(d => d.IdLspNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdLsp)
                .HasConstraintName("FK__SANPHAM__Id_LSP__4AB81AF0");

            entity.HasOne(d => d.IdMauNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdMau)
                .HasConstraintName("FK__SANPHAM__Id_Mau__46E78A0C");

            entity.HasOne(d => d.IdThNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdTh)
                .HasConstraintName("FK__SANPHAM__Id_TH__49C3F6B7");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.IdTk).HasName("PK__TAIKHOAN__16EC19C392AB2C78");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.IdTk).HasColumnName("Id_TK");
            entity.Property(e => e.Loaitk).HasMaxLength(20);
            entity.Property(e => e.Matkhau).HasMaxLength(20);
            entity.Property(e => e.TenNguoiDung).HasMaxLength(200);
            entity.Property(e => e.Tentk).HasMaxLength(50);
        });

        modelBuilder.Entity<Thuonghieu>(entity =>
        {
            entity.HasKey(e => e.IdTh).HasName("PK__THUONGHI__16EC19CC2169136E");

            entity.ToTable("THUONGHIEU");

            entity.Property(e => e.IdTh).HasColumnName("Id_TH");
            entity.Property(e => e.TenTh)
                .HasMaxLength(100)
                .HasColumnName("TenTH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

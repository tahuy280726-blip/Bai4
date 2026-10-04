using Bai4.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Bai4.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SinhVien> SinhViens => Set<SinhVien>();
    public DbSet<Khoa> Khoas => Set<Khoa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SinhVien>()
            .HasIndex(s => s.MaSV)
            .IsUnique();

        modelBuilder.Entity<SinhVien>()
            .HasOne(s => s.Khoa)
            .WithMany(k => k.SinhViens)
            .HasForeignKey(s => s.KhoaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Dữ liệu mẫu
        modelBuilder.Entity<Khoa>().HasData(
            new Khoa { Id = 1, TenKhoa = "Công nghệ thông tin" },
            new Khoa { Id = 2, TenKhoa = "Kinh tế" },
            new Khoa { Id = 3, TenKhoa = "Ngoại ngữ" },
            new Khoa { Id = 4, TenKhoa = "Điện - Điện tử" }
        );

        modelBuilder.Entity<SinhVien>().HasData(
            new SinhVien { Id = 1, MaSV = "SV001", HoTen = "Nguyễn Văn Trung", NgaySinh = new DateTime(2004, 3, 15), GioiTinh = "Nam", Email = "trung.nv@example.com", SoDienThoai = "0901234567", DiaChi = "Hà Nội", KhoaId = 1 },
            new SinhVien { Id = 2, MaSV = "SV002", HoTen = "Trần Thị Hường", NgaySinh = new DateTime(2004, 7, 21), GioiTinh = "Nữ", Email = "huong.tt@example.com", SoDienThoai = "0912345678", DiaChi = "Yên Bái", KhoaId = 2 }
        );
    }
}

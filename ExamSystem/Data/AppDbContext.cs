using Microsoft.EntityFrameworkCore;
using ExamSystem.Models;  // Bu xətti əlavə edin

namespace ExamSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sagird> Sagirdler { get; set; }
        public DbSet<Imtahan> Imtahanlar { get; set; }
        public DbSet<Ders> Dersler { get; set; }
    }
}

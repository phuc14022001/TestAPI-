using Microsoft.EntityFrameworkCore;

namespace testapi.data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options): base(options) { }

        public DbSet<SinhVien> sinhViens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>(e =>
            {
                e.ToTable("sinhVien");
                e.HasKey(sv => sv.Id);
            });
        }
    }
}

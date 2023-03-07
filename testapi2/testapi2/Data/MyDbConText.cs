using Microsoft.EntityFrameworkCore;

namespace testapi2.Data
{
    public class MyDbConText : DbContext
    {
        public MyDbConText(DbContextOptions<MyDbConText> options) : base(options) { }

        public DbSet<Phong> phongs { get; set; }
        public DbSet<Tang> tangs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phong>(e =>
            {
                e.HasKey(p => p.IdPhong);
                e.HasOne(P => P.tang).WithMany(p => p.phongs).HasForeignKey(p => p.IdTang);
                e.ToTable("phongs");
            });
            modelBuilder.Entity<Tang>(e =>
            {
                e.HasKey(p => p.IdTang);
            });
        }
    }

}

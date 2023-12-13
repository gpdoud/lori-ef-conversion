
using Microsoft.EntityFrameworkCore;

namespace lori_ef_conversion;

public class AppDbContext : DbContext {

    public DbSet<Invoice> Invoices { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public AppDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) {
        if(!builder.IsConfigured) {
            builder.UseSqlServer("server=ripper\\sqlexpress;database=LoriDb;User Id=dsi;Password=dsiadmin;trustServerCertificate=true;");
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Dojo.Models
{
  public class DojoContext : DbContext
  {
    public DbSet<Sensei> Senseis { get; set; }
    public DbSet<Disciple> Disciples { get; set; }
    public DbSet<MartialArt> MartialArts { get; set; }
    public DbSet<DiscipleSensei> DiscipleSensei { get; set; }
    public DojoContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
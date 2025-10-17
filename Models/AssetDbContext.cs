using Microsoft.EntityFrameworkCore;

namespace WealthWebApi.Models;

public class AssetDbContext: DbContext
{
    public AssetDbContext(DbContextOptions<AssetDbContext> options)
        : base(options)
    {
    }

    public DbSet<Asset> Assets { get; set; } = null!;

    public DbSet<Holdings> Holdings { get; set; } = null!;

    public DbSet<MajorAssetClasse> MajorAssetClasses { get; set; } = null!;

    public DbSet<AssetClasse> AssetClasses { get; set; } = null!;
}

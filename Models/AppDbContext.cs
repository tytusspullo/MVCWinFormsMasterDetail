using MVCWinFormsMasterDetail;
using System.Data.Entity; 

public class AppDbContext : DbContext 
{
    public DbSet<GrupaPracownicza> GrupyPracownicze { get; set; }
    public DbSet<Pracownik> Pracownicy { get; set; }

    public AppDbContext() : base("Data Source=GPPC\\SQL2022_2;Initial Catalog=TwojaNazwaBazyDanych;User ID=sa;Password=Zedalis22;TrustServerCertificate=False;")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<GrupaPracownicza>()
            .HasKey(g => g.IdGrupyPracowniczej);

        modelBuilder.Entity<Pracownik>() 
            .HasKey(p => p.IdPracownika);

        modelBuilder.Entity<GrupaPracownicza>()
            .HasMany(g => g.Pracownicy)       
            .WithRequired(p => p.GrupaPracownicza) 
            .HasForeignKey(p => p.GrupaPracowniczaId)
            .WillCascadeOnDelete(false); 

        base.OnModelCreating(modelBuilder);
    }
}
